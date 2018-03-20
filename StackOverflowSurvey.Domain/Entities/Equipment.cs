namespace StackOverflowSurvey.Domain.Entities
{
    public class Equipment : IEntity
    {
        public int Id { get; set; }
        public string EquipmentSatisfiedMonitors { get; set; }
        public string EquipmentSatisfiedCPU { get; set; }
        public string EquipmentSatisfiedRAM { get; set; }
        public string EquipmentSatisfiedStorage { get; set; }
        public string EquipmentSatisfiedRW { get; set; }
    }
}