dotnet ef migrations add MigrationName
dotnet ef migrations list
dotnet ef migrations remove

        dotnet ef detabase update [MigrationName]
        dotnet ef database drop -f

        dotnet ef migrations script
        dotnet ef migrations script -o migrations.sql : xuat script
        dotnet ef migrations Name1 Name2


        muon doi type truong pk :
          remove id cu ID
          tao id moi khac ten IDnew
          create --> update --> doi IDnew -> ID
