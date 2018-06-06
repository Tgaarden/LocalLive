namespace LokalLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "MatchName", c => c.String());
            AddColumn("dbo.Matches", "MatchStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "MatchEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "IntermissionStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "IntermissionEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Matches", "MatchStartTime");
            DropColumn("dbo.Matches", "MatchStartEnd");
            DropColumn("dbo.Matches", "MatchIntermissionStart");
            DropColumn("dbo.Matches", "MatchIntermissionEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "MatchIntermissionEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "MatchIntermissionStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "MatchStartEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "MatchStartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Matches", "IntermissionEnd");
            DropColumn("dbo.Matches", "IntermissionStart");
            DropColumn("dbo.Matches", "MatchEnd");
            DropColumn("dbo.Matches", "MatchStart");
            DropColumn("dbo.Matches", "MatchName");
        }
    }
}
