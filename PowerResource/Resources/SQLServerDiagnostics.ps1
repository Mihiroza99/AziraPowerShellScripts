<#
.Synopsis
   Powershell tool for GUI way for getting CPU, Memory and Disk of a machine
.DESCRIPTION
   The tool will ask for file(containing servers name) and folder(where the output will be saved as ServerrInventory.csv.
.EXAMPLE
   It is tool, and has forms and buttons to help you.
.NOTES    
    Author: Prashant kankhara
    Email : prashantkankhara@gmail.com
    Version: 0.1 
    DateCreated: 14th Oct 2020
#>
"Get Diagnostic Details about SQL Server: Server Name, Database Name, TempDB, MasterDB, MSDB, ModelDB file and backup details. "

function Get-ServerDiagnostics {
    
    Param
    (
        [Parameter(Mandatory = $false)]
        $windowsornetwork = $args[0],
        [Parameter(Mandatory = $false)]
        [string]$serverinstance = $args[1],
        [Parameter(Mandatory = $false)]
        [string]$user = $args[2],
        [Parameter(Mandatory = $false)]
        [string]$pass = $args[3],
        [Parameter(Mandatory = $false)]
        $showServerName = $args[4],
        [Parameter(Mandatory = $false)]
        $showDbName = $args[5],
        [Parameter(Mandatory = $false)]
        $showtempDbExist = $args[6],
        [Parameter(Mandatory = $false)]
        $showmodelDbExist = $args[7],
        [Parameter(Mandatory = $false)]
        $showmasterDbExist = $args[8],
        [Parameter(Mandatory = $false)]
        $showMSDbExist = $args[9],
        [Parameter(Mandatory = $false)]
        $showtempDbMoreThanOneFile = $args[10],
        [Parameter(Mandatory = $false)]
        $showmodelback = $args[11],
        [Parameter(Mandatory = $false)]
        $showmasterback = $args[12],
        [Parameter(Mandatory = $false)]
        $showmsdbback = $args[13],
        [Parameter(Mandatory = $false)]
        $showdbback = $args[14],
        [Parameter(Mandatory = $false)]
        $showDbIntegrityCheck = $args[15]
    )

    Begin {
        $output = ""
        $totalspace = 0
        #$outputFolder = "./Output/SqlServerDiagnostics"
       # $outputFile = "/Diagnostic_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".csv"
        # If (!(Test-Path $outputFolder)) {
        #     New-Item -Path $outputFolder -ItemType Directory
        # }
        # If (!(Test-Path "./error_log")) {
        #     New-Item -Path "./error_log" -ItemType Directory
        # }
        try {
            Import-Module SqlServer 
            #           Import-Module SQLPS 
            Import-Module dbatools 
        }
        catch {
            "Installing Prerequistic....Please wait"
            Install-Module dbatools -AllowClobber
            Install-Module SqlServer -AllowClobber
            Import-Module SqlServer 
            #            Import-Module SQLPS 
            Import-Module dbatools 
        }

        if (!$showServerName) {
            if (($showServerName -eq 0)) {
                $showServerName = $false
            }
            else {
                $showServerName = $true
            }
        }
        if (!$showDbName) {
            if (($showDbName -eq 0)) {
                $showDbName = $false
            }
            else {
                $showDbName = $true
            }
        }
        if (!$showtempDbExist) {
            if (($showtempDbExist -eq 0)) {
                $showtempDbExist = $false
            }
            else {
                $showtempDbExist = $true
            }
        }
        if (!$showmodelDbExist) {
            if (($showmodelDbExist -eq 0)) {
                $showmodelDbExist = $false
            }
            else {
                $showmodelDbExist = $true
            }
        }
        if (!$showmasterDbExist) {
            if (($showmasterDbExist -eq 0)) {
                $showmasterDbExist = $false
            }
            else {
                $showmasterDbExist = $true
            }
        }
        if (!$showMSDbExist) {
            if (($showMSDbExist -eq 0)) {
                $showMSDbExist = $false
            }
            else {
                $showMSDbExist = $true
            }
        }
        if (!$showtempDbMoreThanOneFile) {
            if (($showtempDbMoreThanOneFile -eq 0)) {
                $showtempDbMoreThanOneFile = $false
            }
            else {
                $showtempDbMoreThanOneFile = $true
            }
        }
        if (!$showmodelback) {
            if (($showmodelback -eq 0)) {
                $showmodelback = $false
            }
            else {
                $showmodelback = $true
            }
        }
        if (!$showmasterback) {
            if (($showmasterback -eq 0)) {
                $showmasterback = $false
            }
            else {
                $showmasterback = $true
            }
        }
        if (!$showmsdbback) {
            if (($showmsdbback -eq 0)) {
                $showmsdbback = $false
            }
            else {
                $showmsdbback = $true
            }
        }
        if (!$showdbback) {
            if (($showdbback -eq 0)) {
                $showdbback = $false
            }
            else {
                $showdbback = $true
            }
        }
        if (!$showDbIntegrityCheck) {
            if (($showDbIntegrityCheck -eq 0)) {
                $showDbIntegrityCheck = $false
            }
            else {
                $showDbIntegrityCheck = $true
            }
        }

        $useCredential = $true
        if ($windowsornetwork -eq " ") {
            $windowsornetwork = "w"
        }
        if (($windowsornetwork -eq "windows") -or ($windowsornetwork -eq "w")) {
            $useCredential = $false
        }
        else {
            $useCredential = $true
            if ($user -and $pass) {
                $password = ConvertTo-SecureString $pass -AsPlainText -Force
                $pccred = New-Object System.Management.Automation.PSCredential ($user, $password )
            }
        }
    }
    Process {   
        # Import-Module SQLPS
        #$erroFile = "./error_log/sqlserverdiagnostics_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".txt"
        $server_name = $env:COMPUTERNAME
        $ourObject = New-Object -TypeName psobject 
        try {
            if ($showServerName) {
                $output += "`n server_name: $server_name"
                $ourObject | Add-Member -MemberType NoteProperty -Name server_name -Value $server_name
            }
            # $dbName = $database
            # if ($showDbName) {
            #     $output += "`n dbName: $dbName"
            # }
            
            $server = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Server -ArgumentList $serverinstance
            
          
            # $folder = $server.Information.MasterDBLogPath
            $tempFileCount = 0
            $tempDbExist = "Does Not Exists"
            $modelDbExist = "Does Not Exists"
            $masterDbExist = "Does Not Exists"
            $MSDbExist = "Does Not Exists"
            if ($useCredential -eq $true) {
                $databases = (Invoke-Sqlcmd -Query "select name from master.sys.databases"  -ServerInstance $serverinstance -User $user -Password $pass).name
            }
            else {
                $databases = (Invoke-Sqlcmd -Query "select name from master.sys.databases"  -ServerInstance $serverinstance).name
            }
            foreach ($databaseName in $databases) {
                if ($databaseName -eq "tempdb") {
                    $tempDbExist = "Exists: TempDB frequently grows unpredictably, putting your server at risk of running out of C drive space and crashing hard. C is also often much slower than other drives, so performance may be suffering."
                    $global:tempFileCount++
                }
                if ($databaseName -eq "model") {
                    $modelDbExist = "Exists: Putting system databases on the C drive runs the risk of crashing the server when it runs out of space."
                }
                if ($databaseName -eq "master") {
                    $masterDbExist = "Exists: Putting system databases on the C drive runs the risk of crashing the server when it runs out of space."
                }
                if ($databaseName -eq "MSDB") {
                    $MSDbExist = "Exists: Putting system databases on the C drive runs the risk of crashing the server when it runs out of space."
                }
            }

            if ($tempFileCount -GT 1) {
                $tempdbMoreThanOneFile = "TempDB is only configured with one data file. More data files are usually required to alleviate SGAM contention"
            }
            else {
                $tempdbMoreThanOneFile = "TempDB is configured with more than one data file. More data files are usually required to alleviate SGAM contention"
            }


            if ($showtempDbExist) {
                $output += "`n Is TEMPDB Database Exists?  $tempDbExist"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is TEMPDB Database Exists? " -Value $tempDbExist
            }
            if ($showmodelDbExist) {
                $output += "`n modelDbExist: $modelDbExist"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is modelDb Database Exists? " -Value $modelDbExist
            }
            if ($showmasterDbExist) {
                $output += "`n masterDbExist: $masterDbExist"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is masterDb Database Exists? " -Value $masterDbExist
            }
            if ($showMSDbExist) {
                $output += "`n MSDbExist: $MSDbExist"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is msdb Database Exists? " -Value $MSDbExist
            }
            if ($showtempDbMoreThanOneFile) {
                $output += "`n tempdbMoreThanOneFile: $tempdbMoreThanOneFile"
                $ourObject | Add-Member -MemberType NoteProperty -Name "TempDB Only Has 1 Data File? " -Value $tempdbMoreThanOneFile
            }
        
            # # Change the selection of the backupfolder
            # $backupFolder = $server.Settings.BackupDirectory        
            $modelback = "Never"
            $masterback = "Never"
            $msdbback = "Never"
            $dbback = "Never"

            # $backupQuery = "select backup_finish_date,database_name,physical_device_name from msdb.dbo.backupmediafamily INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id 
            # ORDER BY msdb.dbo.backupset.database_name, msdb.dbo.backupset.backup_finish_date"

            $backupQuery  = ";with backup_cte as
            (
                select
                    database_name,
                    backup_type =
                        case type
                            when 'D' then 'database'
                            when 'L' then 'log'
                            when 'I' then 'differential'
                            else 'other'
                        end,
                    backup_finish_date,
                    media_set_id,
                    rownum = 
                        row_number() over
                        (
                            partition by database_name, type 
                            order by backup_finish_date desc
                        )
                from msdb.dbo.backupset
            )
            select
                backup_cte.database_name,
                backup_type,
                backup_cte.backup_finish_date,
                physical_device_name
            from backup_cte
            INNER JOIN msdb.dbo.backupmediafamily ON backup_cte.media_set_id = msdb.dbo.backupmediafamily.media_set_id 
            where rownum = 1
            order by database_name;"

            if ($useCredential -eq $true) {
                $backupRecords = (Invoke-Sqlcmd -Query $backupQuery -ServerInstance $serverinstance -User $user -Password $pass)
            }
            else {
                $backupRecords = (Invoke-Sqlcmd -Query $backupQuery -ServerInstance $serverinstance)
            }

           # $backupRecords
            $index = 0
            foreach ($databaseName in $databases) {
                if ($showDbName) {
                    $output += "`n Database: " + $databaseName
                    $index = $index + 1
                    $propName = "Database " + $index + ": "
                    $ourObject | Add-Member -MemberType NoteProperty -Name $propName -Value $databaseName
                }
                foreach ($backuprecord in $backupRecords) {
                    if ($index -eq 1) {
                        if ($backuprecord.database_name -eq "model") {
                            $modelback = $backuprecord.backup_finish_date
                        }
                        if ($backuprecord.database_name -eq "master") {
                            $masterback = $backuprecord.backup_finish_date
                        }
                        if ($backuprecord.database_name -eq "MSDB") {
                            $msdbback = $backuprecord.backup_finish_date
                        }
                    }

                    if ($backuprecord.database_name -ne "model" -and ($backuprecord.database_name -ne "master") -and ($backuprecord.database_name -ne "MSDB")) {
                        if ($backuprecord.database_name -eq $databaseName) {
                            $dbback = $backuprecord.backup_finish_date
                            if ($showdbback) {
                                $output += "`n " + $databaseName + " Database backup performed : $dbback"
                                $dbkey = "" + $databaseName + " Database backup performed"
                                $ourObject | Add-Member -MemberType NoteProperty -Name $dbkey -Value $dbback
                            }
                        }
                    }
                }
            }

            if ($showmodelback) {
                $output += "`n Model Database backup performed: $modelback"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Model Database backup performed" -Value $modelback
            }
            if ($showmasterback) {
                $output += "`n Master Database backup performed: $masterback"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Master Database backup performed" -Value $masterback
            }
            if ($showmsdbback) {
                $output += "`n MSDB Database backup performed: $msdbback"
                $ourObject | Add-Member -MemberType NoteProperty -Name "MSDB Database backup performed" -Value $msdbback
            }
            
            $dbintegrityCheckQuery = "declare @dbinfo table
            ( ParentObject varchar(255),
            [Object] varchar(255),
            [Field] varchar(255),
            [Value] varchar(255))
            insert into @dbinfo
            execute('dbcc dbinfo(''master'') with tableresults')
            select Value from @dbinfo
            where Field = 'dbi_dbccLastKnownGood'"

            if ($useCredential -eq $true) {
                $dbintegrityCheck = (Invoke-Sqlcmd -Query $dbintegrityCheckQuery -ServerInstance $serverinstance -User $user -Password $pass).value
            }
            else {
                $dbintegrityCheck = (Invoke-Sqlcmd -Query $dbintegrityCheckQuery -ServerInstance $serverinstance).value
            }
            #Get-Date($dbintegrityCheck)

            # $DbIntegrityCheckDate = $server.Databases[3].ExecuteWithResults("DBCC DBINFO () WITH TABLERESULTS").Tables[0] | Where-Object { $_.Field -eq "dbi_dbccLastKnownGood" }  | Select-Object Value
            # $twoWeekBackDate = (Get-Date).AddDays(-14)
            # $dbIntegrityDate = Get-Date($DbIntegrityCheckDate.Value)
            $isBackupInTwoWeeks = (Get-Date).AddDays(-14) -lt (Get-Date($dbintegrityCheck))
           
            if ($isBackupInTwoWeeks -eq $true) {
                $DbIntegrityCheck = "DBCC CHECKDB (Database Integrity check) completed successfully in recent 2 weeks"
            }
            else {
                $DbIntegrityCheck = "DBCC CHECKDB (Database Integrity check) completed successfully in before 2 weeks"
            }
            if ($showDbIntegrityCheck) {
                $output += "`n DbIntegrityCheck: $DbIntegrityCheck"
                $ourObject | Add-Member -MemberType NoteProperty -Name DbIntegrityCheck -Value $DbIntegrityCheck
            }
        }
        catch {
            $err = $_
            $ErrorStackTrace = $_.ScriptStackTrace 
            $ErrorBlock = ($err).ToString() + "`n`nStackTrace: " + ($ErrorStackTrace).ToString()
            #Set-Content -Path $erroFile -Value $ErrorBlock
            #"Some error occured check " + $erroFile + " for stacktrace " 
            $ourObject | Add-Member -MemberType NoteProperty -Name "Error" -Value $ErrorBlock
        }
    }
    End {
        #$output | Export-Csv -Path $outpuFile
        #$filePath = $outputFolder + "/" + $outputFile
        #$ourObject | Out-File -Append $filePath -Encoding UTF8
       # Write-Host "Check the output at File "  $filePath -ForegroundColor Yellow
        return $ourObject
        # return $output | Format-List
    }
}

Get-ServerDiagnostics