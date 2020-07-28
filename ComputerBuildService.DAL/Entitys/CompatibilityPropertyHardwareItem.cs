namespace ComputerBuildService.DAL.Entitys
{
    public class CompatibilityPropertyHardwareItem
    {
        public int PropertyId { get; set; }

        public virtual CompatibilityPropertyEntity Property { get; set; }

        public int ItemId { get; set; }

        public virtual HardwareItemEntity Item { get; set; }
    }
}
