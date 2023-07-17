1. [x] #**CodeFirst ☺**  
 - **Install EntityFramework**  
 - **Configuration:** App.config connectionString Database SQLSERVER   
 - _**Enable migrations command:**_ enable-migrations  
- **_Add Migration command:_** add-migration Create"Name migrations"  
- **_Running migration command:_** Update-Database

1. [x] #**CodeFirst Existing Database☺**
2. enable-migrations
3. add-migration
4. InitialModel-IgnoreChanges -Force
5. update-database


1. [x] #**CodeFirst Reverte Migrations☺**
update-database -TargetMigration:NombreMigracion


1. [x] #**CodeFirst Generation of all migrations in sql format☺**  
Update-­‐Database ­‐Script ­‐SourceMigration:0


1. [x] #**CodeFirst To generate a specific migration use the following command☺**  
Update-­‐Database ­‐Script ‐SourceMigration:Migr1 ‐TargetMigration:Migr2

