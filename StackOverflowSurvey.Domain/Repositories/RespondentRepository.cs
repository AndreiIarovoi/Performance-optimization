﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class RespondentRepository : IRespondentRepository
    {
        private const string Respondents = "Respondents";

        private readonly SurveyContext context;

        public RespondentRepository(SurveyContext context)
        {
            this.context = context;
            this.context.Database.CommandTimeout = 600;
        }

        public IQueryable<Respondent> GetAll()
        {
            return context.Respondents.AsNoTracking();
        }

        public IQueryable<RespondentInfo> GetAllRespondentInfo()
        {
            return (from respondents in context.Respondents
                select new RespondentInfo()
                {
                    Id = respondents.RespondentName,
                    Country = respondents.Country,
                    DeveloperType = respondents.EmploymentInfo.DeveloperType,
                    Gender = respondents.Gender,
                    Professional = respondents.Professional,
                    CompanySize = respondents.EmploymentInfo.CompanySize,
                    Language = respondents.HaveWorkedAndWantInfo.HaveWorkedLanguage,
                    VersionControl = respondents.TechnicalDetailsInfo.VersionControl,
                    WorkStart = respondents.Job.WorkStart,
                    ExperienceLevel = respondents.EmploymentInfo.YearsProgram,
                    CareerSatisfaction = respondents.EmploymentInfo.CareerSatisfaction,
                    JobSatisfaction = respondents.EmploymentInfo.JobSatisfaction
                });
        }

        public IQueryable<RespondentInfo> GetFiltered(RespondentsQuery query)
        {
            IQueryable<RespondentInfo> respondents = GetAllRespondentInfo();

            if (!string.IsNullOrEmpty(query.Professional))
            {
                respondents = respondents.Where(r => r.Professional.Contains(query.Professional));
            }

            if (!string.IsNullOrEmpty(query.Country))
            {
                respondents = respondents.Where(r => r.Country.Contains(query.Country));
            }

            if (!string.IsNullOrEmpty(query.DeveloperType))
            {
                respondents = respondents.Where(r => r.DeveloperType.Contains(query.DeveloperType));
            }

            if (!string.IsNullOrEmpty(query.Language))
            {
                respondents = respondents.Where(r => r.Language.Contains(query.Language));
            }

            if (!string.IsNullOrEmpty(query.VersionControl))
            {
                respondents = respondents.Where(r => r.VersionControl.Contains(query.VersionControl));
            }

            if (!string.IsNullOrEmpty(query.Gender))
            {
                respondents = respondents.Where(r => r.Gender.Contains(query.Gender));
            }

            return respondents;
        }

        public void AddRange(IEnumerable<Respondent> respondents)
        {
            Save("Respondents", respondents, null);
            Save("Assesses", respondents.Select(item => item.Assesses), "Assesses_Id");
            Save("Educations", respondents.Select(item => item.EducationInfo), "EducationInfo_Id");
            Save("Equipments", respondents.Select(item => item.EquipmentInfo), "EquipmentInfo_Id");
            Save("Employments", respondents.Select(item => item.EmploymentInfo), "EmploymentInfo_Id");
            Save("ExCoders", respondents.Select(item => item.ExCoderInfo), "ExCoderInfo_Id");
            Save("HaveWorkedAndWants", respondents.Select(item => item.HaveWorkedAndWantInfo), "HaveWorkedAndWantInfo_Id");
            Save("ImportantHirings", respondents.Select(item => item.ImportantHiringInfo), "ImportantHiringInfo_Id");
            Save("Influences", respondents.Select(item => item.InfluenceInfo), "InfluenceInfo_Id");
            Save("JobInfoes", respondents.Select(item => item.Job), "Job_Id");
            Save("RespondentDetails", respondents.Select(item => item.RespondentDetailsInfo), "RespondentDetailsInfo_Id");
            Save("StackOverflowInfoes", respondents.Select(item => item.StackOverflow), "StackOverflow_Id");
            Save("TechnicalDetails", respondents.Select(item => item.TechnicalDetailsInfo), "TechnicalDetailsInfo_Id");
        }

        private void Save<T>(string tableName, IEnumerable<T> list, string primaryKey)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(context.Database.Connection.ConnectionString))
            {
                DataTable dataTable = this.GetDataTable(list);

                foreach (DataColumn column in dataTable.Columns)
                {
                    sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                sbc.BatchSize = 5000;
                sbc.DestinationTableName = tableName;
                sbc.WriteToServer(dataTable);
            }

            if (tableName != Respondents && !string.IsNullOrEmpty(primaryKey))
            {
                string script = @";WITH Res AS (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS rn FROM [dbo].[Respondents]), Tbl AS (SELECT Id AS Id, ROW_NUMBER() OVER (ORDER BY Id) AS rn FROM [dbo].{0}) UPDATE r SET r.{1} = Tbl.Id FROM [dbo].[Respondents] r INNER JOIN Res ON r.Id = Res.Id INNER JOIN Tbl ON Res.rn = Tbl.rn WHERE r.{2} IS NULL;";

                context.Database.ExecuteSqlCommand(string.Format(script, tableName, primaryKey, primaryKey));
            }
        }

        private DataTable GetDataTable<T>(IEnumerable<T> list)
        {
            DataTable dataTable = new DataTable();

            var props = TypeDescriptor.GetProperties(typeof(T))
                .Cast<PropertyDescriptor>()
                .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                .ToArray();

            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            object[] values = new object[props.Length];

            foreach (var item in list)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}