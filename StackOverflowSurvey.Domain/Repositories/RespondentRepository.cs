using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;

using StackOverflowSurvey.Domain.Dto;
using StackOverflowSurvey.Domain.Entities;

namespace StackOverflowSurvey.Domain.Repositories
{
    public class RespondentRepository : IRespondentRepository
    {
        private readonly SurveyContext context;

        public RespondentRepository(SurveyContext context)
        {
            this.context = context;
            this.context.Database.CommandTimeout = 600;
        }

        public IEnumerable<Respondent> GetAll()
        {
            return context.Respondents.Include(r => r.HaveWorkedAndWantInfo).Include(r => r.EducationInfo)
                .Include(r => r.Job).Include(r => r.EducationInfo).Include(r => r.TechnicalDetailsInfo).Include(r => r.EmploymentInfo).AsEnumerable();
        }

        public IEnumerable<Respondent> GetFiltered(RespondentsQuery query)
        {
            return GetAll().Where(
                r => (string.IsNullOrEmpty(query.Professional) || r.Professional.Contains(query.Professional)) 
                     && (string.IsNullOrEmpty(query.Country) || r.Country.Contains(query.Country))
                     && (string.IsNullOrEmpty(query.DeveloperType) || r.EmploymentInfo.DeveloperType.Contains(query.DeveloperType))
                     && (string.IsNullOrEmpty(query.Language) || r.HaveWorkedAndWantInfo.HaveWorkedLanguage.Contains(query.Language))
                     && (string.IsNullOrEmpty(query.VersionControl) || r.TechnicalDetailsInfo.VersionControl.Contains(query.VersionControl))
                     && (string.IsNullOrEmpty(query.Gender) || r.Gender.Contains(query.Gender)));
        }

        public void AddRange(IEnumerable<Respondent> respondents)
        {
            Save("Respondents", respondents);
            Save("Assesses", respondents.Select(item => item.Assesses));
            Save("Educations", respondents.Select(item => item.EducationInfo));
            Save("Equipments", respondents.Select(item => item.EquipmentInfo));
            Save("Employments", respondents.Select(item => item.EmploymentInfo));
            Save("ExCoders", respondents.Select(item => item.ExCoderInfo));
            Save("HaveWorkedAndWants", respondents.Select(item => item.HaveWorkedAndWantInfo));
            Save("ImportantHirings", respondents.Select(item => item.ImportantHiringInfo));
            Save("Influences", respondents.Select(item => item.InfluenceInfo));
            Save("JobInfoes", respondents.Select(item => item.Job));
            Save("RespondentDetails", respondents.Select(item => item.RespondentDetailsInfo));
            Save("StackOverflowInfoes", respondents.Select(item => item.StackOverflow));
            Save("TechnicalDetails", respondents.Select(item => item.TechnicalDetailsInfo));
        }

        private void Save<T>(string tableName, IEnumerable<T> list)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(context.Database.Connection.ConnectionString))
            {
                DataTable assessesTable = new DataTable();

                var props = TypeDescriptor.GetProperties(typeof(T))
                    .Cast<PropertyDescriptor>()
                    .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                    .ToArray();

                foreach (var prop in props)
                {
                    sbc.ColumnMappings.Add(prop.Name, prop.Name);
                    assessesTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                object[] values = new object[props.Length];

                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }

                    assessesTable.Rows.Add(values);
                }

                sbc.BatchSize = 5000;
                sbc.DestinationTableName = tableName;
                sbc.WriteToServer(assessesTable);
            }
        }
    }
}