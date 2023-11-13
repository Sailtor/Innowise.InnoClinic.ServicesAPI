using FluentMigrator;

namespace Infrastructure.Persistence.Migrations
{
    [Migration(202310310001)]
    public class InitialMigration_202310310001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Services");
            Delete.Table("Categories");
            Delete.Table("Specializations");
        }
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(1024).NotNullable()
                .WithColumn("TimeSlotSize").AsInt32().NotNullable();
            Create.Table("Specializations")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(1024).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
            Create.Table("Services")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Name").AsString(1024).NotNullable()
                .WithColumn("Price").AsDecimal(10, 2).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("CategoryId").AsGuid().NotNullable().ForeignKey("Categories", "Id")
                .WithColumn("SpecializationId").AsGuid().NotNullable().ForeignKey("Specializations", "Id");
        }
    }
}
