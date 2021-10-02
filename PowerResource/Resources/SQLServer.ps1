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
function Get-MachineDetails {
    
    <#
        .PARAMETER database
            Sets name of the Database you want details of.
    #>
    Param
    (
        [Parameter(Mandatory = $false)]
        [string]$database = $args[0],
        [Parameter(Mandatory = $false)]
        [string]$windowsornetwork = $args[1],
        [Parameter(Mandatory = $false)]
        [string]$serverinstance = $args[2],
        [Parameter(Mandatory = $false)]
        [string]$user = $args[3],
        [Parameter(Mandatory = $false)]
        [string]$pass = $args[4],
        [Parameter(Mandatory = $false)]
        $showWindowsVersion = $args[5],
        [Parameter(Mandatory = $false)]
        $showSqlProductDetails = $args[6],
        [Parameter(Mandatory = $false)]
        $showCDriveSpace = $args[7],
        [Parameter(Mandatory = $false)]
        $showSqlMemoryDetails = $args[8],
        [Parameter(Mandatory = $false)]
        $showDriveSpaceDetails = $args[9],
        [Parameter(Mandatory = $false)]
        $showBackupPath = $args[10],
        [Parameter(Mandatory = $false)]
        $showLDFSize = $args[11],
        [Parameter(Mandatory = $false)]
        $showServerVersion = $args[12],
        [Parameter(Mandatory = $false)]
        $showProductLevel = $args[13],
        [Parameter(Mandatory = $false)]
        $showFullTextSearchEnabled = $args[14],
        [Parameter(Mandatory = $false)]
        $showSqlLanguage = $args[15],
        [Parameter(Mandatory = $false)]
        $showSqlEdition = $args[16],
        [Parameter(Mandatory = $false)]
        $showdbCollationName = $args[17],
        [Parameter(Mandatory = $false)]
        $showCLRVersion = $args[18],
        [Parameter(Mandatory = $false)]
        $showSqlPort = $args[19],
        [Parameter(Mandatory = $false)]
        $showServerName = $args[20],
        [Parameter(Mandatory = $false)]
        $showRecomendedCpu = $args[21],
        [Parameter(Mandatory = $false)]
        $showNumberFormat = $args[22],
        [Parameter(Mandatory = $false)]
        $showSqlLicense = $args[23],
        [Parameter(Mandatory = $false)]
        $showMaxDop = $args[24],
        [Parameter(Mandatory = $false)]
        $showNumaNodes = $args[25],
        [Parameter(Mandatory = $false)]
        $showCostOfThreshold = $args[26],
        [Parameter(Mandatory = $false)]
        $showServerType = $args[27],
        [Parameter(Mandatory = $false)]
        $showDbName = $args[28],
        [Parameter(Mandatory = $false)]
        $showDbMailEnabled = $args[29],
        [Parameter(Mandatory = $false)]
        $showDbMailStatus = $args[30],
        [Parameter(Mandatory = $false)]
        $showFileStramConfigLevel = $args[31],
        [Parameter(Mandatory = $false)]
        $showFilestreamAccessLevel = $args[32],
        [Parameter(Mandatory = $false)]
        $showFilestreamSize = $args[33],
        [Parameter(Mandatory = $false)]
        $showClrEnabled = $args[34],
        [Parameter(Mandatory = $false)]
        $showDbRecoveryModel = $args[35],
        [Parameter(Mandatory = $false)]
        $showDbCompatibilityLevel = $args[36],
        [Parameter(Mandatory = $false)]
        $showDbLastBackupDate = $args[37],
        [Parameter(Mandatory = $false)]
        $showTempLDFPath = $args[38],
        [Parameter(Mandatory = $false)]
        $showTempMDFPath = $args[39],
        [Parameter(Mandatory = $false)]
        $showMDFPath = $args[40],
        [Parameter(Mandatory = $false)]
        $showMDFSize = $args[41],
        [Parameter(Mandatory = $false)]
        $showAuthenticationMode = $args[41],
        [Parameter(Mandatory = $false)]
        $showAdminList = $args[41],
        [Parameter(Mandatory = $false)]
        $showDbLastRestoreDate = $args[42]

    )

    Begin {
        $output = ""
        $totalspace = 0
        #$outputFolder = "./Output/SqlServer"
        #$outputFile = "/SqlServer_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".csv"
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
        if (!$showWindowsVersion) {
            if (($showWindowsVersion -eq 0)) {
                $showWindowsVersion = $false
            }
            else {
                $showWindowsVersion = $true
            }
        }
        if (!$showSqlProductDetails) {
            if (($showSqlProductDetails -eq 0)) {
                $showSqlProductDetails = $false
            }
            else {
                $showSqlProductDetails = $true
            }
        }
        if (!$showCDriveSpace) {
            if (($showCDriveSpace -eq 0)) {
                $showCDriveSpace = $false
            }
            else {
                $showCDriveSpace = $true
            }
        }
        if (!$showSqlMemoryDetails) {
            if (($showSqlMemoryDetails -eq 0)) {
                $showSqlMemoryDetails = $false
            }
            else {
                $showSqlMemoryDetails = $true
            }
        }
        if (!$showDriveSpaceDetails) {
            if (($showDriveSpaceDetails -eq 0)) {
                $showDriveSpaceDetails = $false
            }
            else {
                $showDriveSpaceDetails = $true
            }
        }
        if (!$showBackupPath) {
            if (($showBackupPath -eq 0)) {
                $showBackupPath = $false
            }
            else {
                $showBackupPath = $true
            }
        }
        if (!$showLDFSize) {
            if (($showLDFSize -eq 0)) {
                $showLDFSize = $false
            }
            else {
                $showLDFSize = $true
            }
        }
        if (!$showServerVersion) {
            if (($showServerVersion -eq 0)) {
                $showServerVersion = $false
            }
            else {
                $showServerVersion = $true
            }
        }
        if (!$showProductLevel) {
            if (($showProductLevel -eq 0)) {
                $showProductLevel = $false
            }
            else {
                $showProductLevel = $true
            }
        }
        if (!$showFullTextSearchEnabled) {
            if (($showFullTextSearchEnabled -eq 0)) {
                $showFullTextSearchEnabled = $false
            }
            else {
                $showFullTextSearchEnabled = $true
            }
        }
        if (!$showSqlLanguage) {
            if (($showSqlLanguage -eq 0)) {
                $showSqlLanguage = $false
            }
            else {
                $showSqlLanguage = $true
            }
        }
        if (!$showSqlEdition) {
            if (($showSqlEdition -eq 0)) {
                $showSqlEdition = $false
            }
            else {
                $showSqlEdition = $true
            }
        }
        if (!$showdbCollationName) {
            if (($showdbCollationName -eq 0)) {
                $showdbCollationName = $false
            }
            else {
                $showdbCollationName = $true
            }
        }
        if (!$showCLRVersion) {
            if (($showCLRVersion -eq 0)) {
                $showCLRVersion = $false
            }
            else {
                $showCLRVersion = $true
            }
        }
        if (!$showSqlPort) {
            if (($showSqlPort -eq 0)) {
                $showSqlPort = $false
            }
            else {
                $showSqlPort = $true
            }
        }
        if (!$showServerName) {
            if (($showServerName -eq 0)) {
                $showServerName = $false
            }
            else {
                $showServerName = $true
            }
        }
        if (!$showRecomendedCpu) {
            if (($showRecomendedCpu -eq 0)) {
                $showRecomendedCpu = $false
            }
            else {
                $showRecomendedCpu = $true
            }
        }
        if (!$showNumberFormat) {
            if (($showNumberFormat -eq 0)) {
                $showNumberFormat = $false
            }
            else {
                $showNumberFormat = $true
            }
        }
        if (!$showSqlLicense) {
            if (($showSqlLicense -eq 0)) {
                $showSqlLicense = $false
            }
            else {
                $showSqlLicense = $true
            }
        }
        if (!$showMaxDop) {
            if (($showMaxDop -eq 0)) {
                $showMaxDop = $false
            }
            else {
                $showMaxDop = $true
            }
        }
        if (!$showNumaNodes) {
            if (($showNumaNodes -eq 0)) {
                $showNumaNodes = $false
            }
            else {
                $showNumaNodes = $true
            }
        }
        if (!$showCostOfThreshold) {
            if (($showCostOfThreshold -eq 0)) {
                $showCostOfThreshold = $false
            }
            else {
                $showCostOfThreshold = $true
            }
        }
        if (!$showServerType) {
            if (($showServerType -eq 0)) {
                $showServerType = $false
            }
            else {
                $showServerType = $true
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
        if (!$showDbMailEnabled) {
            if (($showDbMailEnabled -eq 0)) {
                $showDbMailEnabled = $false
            }
            else {
                $showDbMailEnabled = $true
            }
        }
        if (!$showDbMailStatus) {
            if (($showDbMailStatus -eq 0)) {
                $showDbMailStatus = $false
            }
            else {
                $showDbMailStatus = $true
            }
        }
        if (!$showFileStramConfigLevel) {
            if (($showFileStramConfigLevel -eq 0)) {
                $showFileStramConfigLevel = $false
            }
            else {
                $showFileStramConfigLevel = $true
            }
        }
        if (!$showFilestreamAccessLevel) {
            if (($showFilestreamAccessLevel -eq 0)) {
                $showFilestreamAccessLevel = $false
            }
            else {
                $showFilestreamAccessLevel = $true
            }
        }
        if (!$showFilestreamSize) {
            if (($showFilestreamSize -eq 0)) {
                $showFilestreamSize = $false
            }
            else {
                $showFilestreamSize = $true
            }
        }
        if (!$showClrEnabled) {
            if (($showClrEnabled -eq 0)) {
                $showClrEnabled = $false
            }
            else {
                $showClrEnabled = $true
            }
        }

        if (!$showDbRecoveryModel) {
            if (($showDbRecoveryModel -eq 0)) {
                $showDbRecoveryModel = $false
            }
            else {
                $showDbRecoveryModel = $true
            }
        }
        if (!$showDbCompatibilityLevel) {
            if (($showDbCompatibilityLevel -eq 0)) {
                $showDbCompatibilityLevel = $false
            }
            else {
                $showDbCompatibilityLevel = $true
            }
        }
        if (!$showDbLastBackupDate) {
            if (($showDbLastBackupDate -eq 0)) {
                $showDbLastBackupDate = $false
            }
            else {
                $showDbLastBackupDate = $true
            }
        }
        if (!$showTempLDFPath) {
            if (($showTempLDFPath -eq 0)) {
                $showTempLDFPath = $false
            }
            else {
                $showTempLDFPath = $true
            }
        }
        if (!$showTempMDFPath) {
            if (($showTempMDFPath -eq 0)) {
                $showTempMDFPath = $false
            }
            else {
                $showTempMDFPath = $true
            }
        }
        if (!$showMDFPath) {
            if (($showMDFPath -eq 0)) {
                $showMDFPath = $false
            }
            else {
                $showMDFPath = $true
            }
        }
        if (!$showMDFSize) {
            if (($showMDFSize -eq 0)) {
                $showMDFSize = $false
            }
            else {
                $showMDFSize = $true
            }
        }
        if (!$showAdminList) {
            if (($showAdminList -eq 0)) {
                $showAdminList = $false
            }
            else {
                $showAdminList = $true
            }
        }
        if (!$showAuthenticationMode) {
            if (($showAuthenticationMode -eq 0)) {
                $showAuthenticationMode = $false
            }
            else {
                $showAuthenticationMode = $true
            }
        }
        if (!$showDbLastRestoreDate) {
            if (($showDbLastRestoreDate -eq 0)) {
                $showDbLastRestoreDate = $false
            }
            else {
                $showDbLastRestoreDate = $true
            }
        }

        $useCredential = $true
        if ($windowsornetwork -eq " ") {
            $windowsornetwork = "w"
        }
        if (($windowsornetwork -eq "windows") -or ($windowsornetwork -eq "w")) {
            $useCredential = $false
        } else {
            if ($user -and $pass) {
                $password = ConvertTo-SecureString $pass -AsPlainText -Force
                $pccred = New-Object System.Management.Automation.PSCredential ($user, $password )
            }
        }
    }
    Process {   
        # Install-Module SqlServer -AllowClobber
        # Import-Module SQLPS
        # Import-Module SqlServer
        #$erroFile = "./error_log/sqlserver_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".txt"
        $server_name = $env:COMPUTERNAME
        $ourObject = New-Object -TypeName psobject 
        try {
            
            $output += "`n================================================"
            $output += "`n Windows Details"
            $output += "`n================================================"
            if ($showWindowsVersion) {
                $WindowsVersion = (systeminfo | Select-String 'OS Version:')[0].ToString().Split(':')[1].Trim()
                $WindowsName = (systeminfo | Select-String 'OS Name:')[0].ToString().Split(':')[1].Trim()
                $output += "`n `nWindows Details:" + $WindowsName  + " - " + $WindowsVersion 
                $windowsvalue =  ""  + $WindowsName  + " - " + $WindowsVersion 
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Details" -Value $windowsvalue
            }
            if ($showSqlMemoryDetails) {
                if ($useCredential -eq $true) {
                    #$serverinstance
                    #$user
                    #$pass
                    $UsedMemorybySql = (Invoke-SqlCmd -Query "SELECT physical_memory_in_use_kb/1024 AS sqlusedmemory FROM sys.dm_os_process_memory;" -ServerInstance $serverinstance -User $user -Password $pass)
                } else {
                    $UsedMemorybySql = (Invoke-SqlCmd -Query "SELECT physical_memory_in_use_kb/1024 AS sqlusedmemory FROM sys.dm_os_process_memory;" -ServerInstance $serverinstance)
                }
                $output += "`n Total Memory In Use: " + $UsedMemorybySql.sqlusedmemory + "MB"
				$inusedmemory = "" + $UsedMemorybySql.sqlusedmemory + "MB"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Total Memory In Use" -Value $inusedmemory
                if ($useCredential -eq $true) {
                    $availableMemorybySql = Invoke-SqlCmd -Query "SELECT available_commit_limit_kb/1024 AS sqlavailmemory FROM sys.dm_os_process_memory;" -ServerInstance $serverinstance -User $user -Password $pass
                } else {
                    $availableMemorybySql = Invoke-SqlCmd -Query "SELECT available_commit_limit_kb/1024 AS sqlavailmemory FROM sys.dm_os_process_memory;" -ServerInstance $serverinstance 
                }
                $totalMemoryforSQL = $availableMemorybySql.sqlavailmemory + $UsedMemorybySql.sqlusedmemory
                $output += "`n Total Memory Allocated: " + $totalMemoryforSQL + "MB"
                $memoryValue = "" + $totalMemoryforSQL + "MB"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Total Memory Allocated" -Value $memoryValue
            }
            if ($showCDriveSpace) {
                $used = (Get-PSDrive C | Select-Object Used).Used / 1MB
                $free = (Get-PSDrive C | Select-Object Free).Free / 1MB
                $output += "`n Hard Drive C Drive: [Used: " + [math]::Round($used,2) + "/ Free: " + [math]::Round($free,2) + "MB]"
                $hardDriveValue = "Hard Drive C Drive: [Used: " + [math]::Round($used,2) + "/Free: " + [math]::Round($free,2) + "MB]"
                $ourObject | Add-Member -MemberType NoteProperty -Name "C Drive Details" -Value $hardDriveValue
            }
            if ($showDriveSpaceDetails) {
                $allDriveSpace = Get-WmiObject -Class win32_logicaldisk -ComputerName $server_name
    
                $totalAvailableSpace = 0;
                $totalSpace = 0;
        
                foreach ($drive in $allDriveSpace) {
                    $totalAvailableSpace += $drive.FreeSpace
                    $totalSpace += $drive.Size
                }
                $totalAvailableSpace = "" + [math]::Round($totalAvailableSpace / 1MB,2) + " MB" 
                $totalSpace = "" + [math]::Round($totalSpace / 1MB,2) + " MB"
                $output += "`n Available Physical Memory: $totalAvailableSpace"
                $output += "`n Total Physical Memory: $totalSpace"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Available Physical Memory" -Value $totalAvailableSpace
                $ourObject | Add-Member -MemberType NoteProperty -Name "Total Physical Memory" -Value $totalSpace
            }
            $output += "`n================================================"
            $output += "`n Sql Server  Details"
            $output += "`n================================================"
            $ServerName = $env:COMPUTERNAME

             
            $CPUCore = (Get-CIMInstance -Class 'CIM_Processor').NumberOfCores
            $RAM = (systeminfo | Select-String 'Total Physical Memory:').ToString().Split(':')[1].Trim()
            $drives = Get-WmiObject Win32_LogicalDisk -ComputerName $ServerName | Select -Property Size
            
            foreach ($drive  in $drives) {
                $drivename = $drive. -split ":"
                if (($drivename -ne "A") -and ($drivename -ne "B")) {
                    $totalspace += [int]($drive.Size / 1GB)
                }
            }
            $RAMGB = [int]($RAM.Split(' ')[0].Trim() / 1024) 
            
            if ($showServerName) {
                $output += "`n Server Name : " + $ServerName
                $ourObject | Add-Member -MemberType NoteProperty -Name "Server Name" -Value $ServerName
            }
            if ($showRecomendedCpu) {
                $output += "`n CPU Details [SQL Server] : CPUCore=" + $CPUCore + ",RAM=" + $RAMGB + " GB,DISK=" + $totalspace + " GB"
                $recomValue = "CPUCore=" + $CPUCore + ",RAM=" + $RAMGB + " GB,DISK=" + $totalspace + " GB"
                $ourObject | Add-Member -MemberType NoteProperty -Name "CPU Details [SQL Server]" -Value $recomValue
            }
            if ($showSqlProductDetails) {
                if ($useCredential -eq $true) {
                    $SqlProductDetails = (Invoke-SqlCmd -query "select @@version" -ServerInstance $serverinstance -User $user -Password $pass).Column1
                } else {
                    $SqlProductDetails = (Invoke-SqlCmd -query "select @@version" -ServerInstance $serverinstance).Column1
                }
                $output += "`n SqlProductDetails: $SqlProductDetails"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SqlProductDetails" -Value $SqlProductDetails
            }

            $server = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Server -ArgumentList $serverinstance
            $databases = $server.Databases
            $databaseExist = $false
            foreach ($db in $databases) {
                If ($db.Name -eq $database) {
                    $databaseExist = $true
                }
            }
            if ($databaseExist) {
                
            }
            else {
                $database + " does not Exist!"
            }

            if ($showServerVersion) {
                $serverVersion = $server.Information.VersionString
                $output += "`n serverVersion: $serverVersion"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Server Version" -Value $serverVersion
            }
            if ($showProductLevel) {
                $productLevel = $server.Information.ProductLevel
                $output += "`n productLevel: $productLevel"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Product Level" -Value $productLevel
            }
            if ($showFullTextSearchEnabled) {
                $FullTextSearchEnabled = $server.Information.IsFullTextInstalled
                $output += "`n FullTextSearchEnabled: $FullTextSearchEnabled"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Full TextSearch is enabled?" -Value $FullTextSearchEnabled
            }
            if ($showSqlLanguage) {
                $SqlLanguage = $server.Information.Language
                $output += "`n SqlLanguage: $SqlLanguage"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Sql Language" -Value $SqlLanguage
            }
            if ($showSqlEdition) {
                $SqlEdition = $server.Information.Edition
                $output += "`n SqlEdition: $SqlEdition"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Sql Edition" -Value $SqlEdition
            }
            if ($showdbCollationName) {
                $collationQuery = "Select DATABASEPROPERTYEX('" + $database + "','Collation') as DBCollation"
                if ($useCredential -eq $true) {
                    $dbCollationName = (Invoke-Sqlcmd -Query $collationQuery -ServerInstance $serverinstance -User $user -Password $pass).DBCollation
                } else {
                    $dbCollationName = (Invoke-Sqlcmd -Query $collationQuery -ServerInstance $serverinstance).DBCollation
                }
                $output += "`n dbCollationName: $dbCollationName"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Collation Name" -Value $dbCollationName
            }
            if ($showCLRVersion) {
                $CLR = "v" + $PSVersionTable.CLRVersion.Major.ToString() + "." + $PSVersionTable.CLRVersion.Minor.ToString() + "." + $PSVersionTable.CLRVersion.Build.ToString()
                $output += "`n CLR Version $CLR"
                $ourObject | Add-Member -MemberType NoteProperty -Name "CLR Version" -Value $CLR
            }
            if ($showSqlPort) {
                # Dont use Invoke-Sqlcmd for below syntax. It will not work 
                $sql_services = Get-WmiObject -Query "select * from win32_service where PathName like '%%sqlservr.exe%%'" -ComputerName $server_name -ErrorAction Stop
                $processID = $sql_services.ProcessID[0]
    
                if ($processID -ne "") {
                    $SQLPort = (((netstat -ano | findstr $processID)[0].ToString().Split('') | where { $_ -ne "" })[1].Split(":"))[1]
                }
                else {
                    $SQLPort = "N/A"
                }
            
                $output += "`n PORT: $SQLPort"
            }
           
           
            
            
            if ($showNumberFormat) {
                if ($useCredential -eq $true) {
                    $numberFormat = (Invoke-Sqlcmd -Query "select format(987654321.00, 'N', 'en-us' );" -ServerInstance $serverinstance -User $user -Password $pass).Column1
                } else {
                    $numberFormat = (Invoke-Sqlcmd -Query "select format(987654321.00, 'N', 'en-us' );" -ServerInstance $serverinstance).Column1
                }
                $output += "`n Number Format(en-us): $numberFormat"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Number Format(en-us)" -Value $numberFormat
            }
            if ($showSqlLicense) {
                if ($useCredential -eq $true) {
                    $sysInfo = Invoke-Sqlcmd -Query "SELECT * FROM sys.dm_os_sys_info" -ServerInstance $serverinstance -User $user -Password $pass
                } else {
                    $sysInfo = Invoke-Sqlcmd -Query "SELECT * FROM sys.dm_os_sys_info" -ServerInstance $serverinstance
                }

                $sockets = $sysInfo.socket_count
                $coresPerSocket = $sysInfo.cores_per_socket
                $logicalProcessors = (Get-CimInstance Win32_ComputerSystem) | Select  NumberOfLogicalProcessors
                $sqlLicense = "SQL Server detected " + $sockets + " sockets with " + $coresPerSocket.NumberOfLogicalProcessors + " cores per socket and " + $logicalProcessors.NumberOfLogicalProcessors + " logical processors per socket, " + $logicalProcessors.NumberOfLogicalProcessors + " total logical processors; using 4 logical processors based on SQL Server licensing."
                $output += "`n SQL License: $sqlLicense"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SQL License" -Value $sqlLicense
            }
            if ($showMaxDop) {
                $sqlHardwareDetails = (Test-DbaMaxDop -SqlInstance $env:COMPUTERNAME | Select-Object *)[0]
                $dbMaxDOP = $sqlHardwareDetails.DatabaseMaxDop
                #sp_configure 'max degree of parallelism'
                $output += "`n Max DOP: $dbMaxDOP"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Max DOP" -Value $dbMaxDOP
            }
            if ($showNumaNodes) {
                $NumaNodes = $sqlHardwareDetails.NumaNodes
                $output += "`n NUMA Nodes: $NumaNodes"
                $ourObject | Add-Member -MemberType NoteProperty -Name "NUMA Nodes" -Value $NumaNodes
            }
            if ($showCostOfThreshold) {
                if ($useCredential -eq $true) {
                    $costThresholdDOP = (Invoke-Sqlcmd -Query "SELECT value FROM sys.configurations WITH (NOLOCK) WHERE name IN ('cost threshold for parallelism')" -ServerInstance $serverinstance -User $user -Password $pass).value
                } else {
                    $costThresholdDOP = (Invoke-Sqlcmd -Query "SELECT value FROM sys.configurations WITH (NOLOCK) WHERE name IN ('cost threshold for parallelism')" -ServerInstance $serverinstance).value
                }
                $output += "`n Cost of Threshold DOP: $costThresholdDOP"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Cost of Threshold DOP" -Value $costThresholdDOP
            }
            if ($showServerType) {
                $ServerType = (Get-WmiObject -ComputerName $ServerName -class Win32_ComputerSystem | Select -Property Model).Model
                $output += "`n Server TYPE: $ServerType"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Server TYPE" -Value $ServerType
            }
            if ($showDbName) {
                $output += "`n dbName: $database"
                $ourObject | Add-Member -MemberType NoteProperty -Name "DataBase Name" -Value $database
            }
            $server = New-Object ('Microsoft.SqlServer.Management.Smo.Server') $serverinstance
            if ($databaseExist) {
                if ($showDbMailEnabled) {
                    $isDatabaseMailEnabled = $server.Configuration.DatabaseMailEnabled.ConfigValue
                    $output += "`n isDatabaseMailEnabled: $isDatabaseMailEnabled"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Is Database Mail Enabled?" -Value $isDatabaseMailEnabled
                }
                if ($showDbMailStatus) {
                    $databaseMailStatus = $server.Configuration.DatabaseMailEnabled.RunValue
                    $output += "`n databaseMailStatus: $databaseMailStatus"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Database Mail Status?" -Value $databaseMailStatus
                }
                if ($showFileStramConfigLevel) {
                    $FileStreamConfigLevel = $server.Configuration.FilestreamAccessLevel.ConfigValue
                    $output += "`n FileStreamConfigLevel: $FileStreamConfigLevel"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Filestream config Level?" -Value $FileStreamConfigLevel
                }
                if ($showFilestreamAccessLevel) {
                    $FileStreamAccessLevel = $server.Configuration.FilestreamAccessLevel.RunValue
                    $output += "`n FileStreamAccessLevel: $FileStreamAccessLevel"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Filestream access Level?" -Value $FileStreamAccessLevel
                }
                if ($showFilestreamSize) {
                    $FileStreamFileSize = 0;
                    $FileStreamFilePath = "Filestream Not enabled in DB.";
                    if ($FileStreamConfigLevel -ne 0) {
                        if ($useCredential -eq $true) {
                            $dbfiles = Invoke-Sqlcmd -Query "Use $database Select * from sys.database_files;" -ServerInstance $serverinstance -User $user -Password $pass
                        } else {
                            $dbfiles = Invoke-Sqlcmd -Query "Use $database Select * from sys.database_files;" -ServerInstance $serverinstance
                        }
        
                        foreach ($file in $dbfiles) {
                            if ($file.type_desc -eq "FILESTREAM") {
                                $FileStreamFileSize = $file.size
                                $FileStreamFilePath = $file.physical_name
                            }
                        }
                    }

                    # Change the backup path using sql query
                    if ($showBackupPath) {
                        $backupPath = ($server.Settings.BackupDirectory).ToString() + $database + ".bak"
                        $output += "`n backupPath: $backupPath"    
                        $ourObject | Add-Member -MemberType NoteProperty -Name "BackUp Path" -Value $backupPath
                    }
               
                
                    $output += "`n FILESTREAM FILE Path: $FileStreamFilePath"
                    $output += "`n FILESTREAM FILE Size: $FileStreamFileSize"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "FILESTREAM FILE Path" -Value $FileStreamFilePath
                    $ourObject | Add-Member -MemberType NoteProperty -Name "FILESTREAM FILE Size" -Value $FileStreamFileSize
                }
            }
            else {
                "Database Not Found!"
            }

            $adminQuery = "select name,type_desc as LoginType, is_disabled as isDisabled FROM master.sys.server_principals WHERE IS_SRVROLEMEMBER ('sysadmin',name) = 1 ORDER BY name"
            if ($useCredential -eq $true) {
                $admins = (Invoke-Sqlcmd -Query $adminQuery -ServerInstance $serverinstance -User $user -Password $pass)
            }
            else {
                $admins = (Invoke-Sqlcmd -Query $adminQuery -ServerInstance $serverinstance)
            }

            if ($showAdminList) {
                foreach ($admin in $admins) {
                    $output += "`n Administrator: $admins"
                    $value = "Type: " + $admin.LoginType + ",Disabled: " + $admin.isDisabled
                    $ourObject | Add-Member -MemberType NoteProperty -Name $admin.Name -Value $value     
                }
            }

            if ($showClrEnabled) {
                if ($useCredential -eq $true) {
                    $isClrEnabled = ( Invoke-Sqlcmd -query "SELECT * FROM sys.configurations WHERE name = 'clr enabled'" -ServerInstance $serverinstance -User $user -Password $pass).value  
                } else {
                    $isClrEnabled = ( Invoke-Sqlcmd -query "SELECT * FROM sys.configurations WHERE name = 'clr enabled'" -ServerInstance $serverinstance).value  
                }
                $output += "`n isClrEnabled: $isClrEnabled"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is Clear Enabled" -Value $isClrEnabled
            }

            foreach ($db in $server.Databases) {
                if ($db.Name -eq $database) {
                    if ($showDbRecoveryModel) {
                        $dbRecoveryModel = $db.RecoveryModel
                        $output += "`n dbRecoveryModel: $dbRecoveryModel"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "DB Recovery Model" -Value $dbRecoveryModel
                    }
                    if ($showDbCompatibilityLevel) {
                        $dbCompatibilityLevel = $db.CompatibilityLevel
                        $output += "`n dbCompatibilityLevel: $dbCompatibilityLevel"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "DB Compatibility Level" -Value $dbCompatibilityLevel
                    }
                    if ($showDbLastBackupDate) {
                        $dbLastBackupDate = $db.LastBackupDate.ToString("MM/dd/yyyy")
                        if ($dbLastBackupDate -eq "01/01/0001") {
                            $output += "`n dbLastBackupDate: N/A"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "DB Last backup date" -Value "N/A"
                        }
                        else {
                            $output += "`n dbLastBackupDate: $dbLastBackupDate"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "DB Last backup date" -Value $dbLastBackupDate
                        }
                    }
                    if ($showDbLastRestoreDate) {
                        $restoreQuery = "SELECT top 1 [restore_date] as date FROM [msdb].[dbo].[restorehistory] where destination_database_name = '" + $database +"' order by restore_date desc"
                        if ($useCredential -eq $true) {
                            $dbLastRestoreDate = (Invoke-Sqlcmd -Query $restoreQuery -ServerInstance $serverinstance -User $user -Password $pass).date
                        }
                        else {
                            $dbLastRestoreDate = (Invoke-Sqlcmd -Query $restoreQuery -ServerInstance $serverinstance).date
                        }
                        if ($dbLastRestoreDate -eq "01/01/0001") {
                            $output += "`n showDbLastRestoreDate: N/A"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "DB Last Restore date" -Value "N/A"
                        }
                        else {
                            $output += "`n dbLastRestoreDate: $dbLastRestoreDate"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "DB Last Restore date" -Value $dbLastRestoreDate
                        }
                    }
                }
            }

            if ($showAuthenticationMode) {
                $authenticationMode = $server.Settings.LoginMode
                $output += $authenticationMode
                $ourObject | Add-Member -MemberType NoteProperty -Name "Authentication Mode" -Value $dbMdfSize
            }

            $tempdbMdfldfsizeQuery = "SELECT DB_NAME(database_id) AS dbName, 
                CASE WHEN type_desc = 'ROWS' THEN 'MDF' ELSE 'LDF' END as FileType, 
                name AS FileName, 
                size/128.0 AS FileSize,
                s.physical_name as FilePath
            FROM sys.master_files s
            WHERE  type IN (0,1) and name LIKE 'tempdb%'"

                if ($useCredential -eq $true) {
                    $reportServerRecords = (Invoke-Sqlcmd -Query $tempdbMdfldfsizeQuery -ServerInstance $serverinstance -User $user -Password $pass)
                }
                else {
                    $reportServerRecords = (Invoke-Sqlcmd -Query $tempdbMdfldfsizeQuery -ServerInstance $serverinstance)
                }

                foreach ($item in $reportServerRecords) {
                    if ($item.FileType -eq "MDF") {
                        if ($showssrsDBmdfPath) {
                            $output += "`n Temp DB MDF Path: " + $item.FilePath
                            $ourObject | Add-Member -MemberType NoteProperty -Name "Temp DB MDF Path" -Value $item.FilePath
                        }
                        if ($showssrsDBmdfSize) {
                            $output += "`n Temp DB MDF Size: " + $item.FileSize + " MB"
                            $dbMdfSize = "" + $item.FileSize + " MB"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "Temp DB MDF Size" -Value $dbMdfSize
                        }
                    }
                    if ($item.FileType -eq "LDF") {
                        if ($showssrsDBldfPath) {
                            $output += "`n Temp DB LDF Path: " + $item.FilePath
                            $ourObject | Add-Member -MemberType NoteProperty -Name "Temp DB LDF Path" -Value $item.FilePath
                        }
                        if ($showssrsDBldfSize) {
                            $output += "`n Temp DB LDF Size: " + $item.FileSize + " MB"
                            $dbLdfSize = "" + $item.FileSize + " MB"
                            $ourObject | Add-Member -MemberType NoteProperty -Name "Temp DB LDF Size" -Value $dbLdfSize
                        }
                    }
                }
            
            #$folder = $server.Information.MasterDBLogPath
            # if ($useCredential -eq $true) {
            #     $databasesFiles = (Invoke-Sqlcmd -Query "SELECT physical_name FROM sys.master_files"  -ServerInstance $serverinstance -User $user -Password $pass).physical_name
            # } else {
            #     $databasesFiles = (Invoke-Sqlcmd -Query "SELECT physical_name FROM sys.master_files"  -ServerInstance $serverinstance).physical_name
            # }
            # foreach ($file in Get-ChildItem $databasesFiles) {
            #     if ($file.Name -contains "templog.ldf") {
            #         if ($showTempLDFPath) {
            #             $tempDbLdfPath = $folder + "\" + $file.Name
            #             $output += "`n tempDbLdfPath:$tempDbLdfPath"
            #             $ourObject | Add-Member -MemberType NoteProperty -Name "Temp Db Ldf Path" -Value $tempDbLdfPath
            #         }
            #     }
            #     if ($file.Name -contains "templog.mdf") {
            #         if ($showTempMDFPath) {
            #             $tempDbmdfPath = $folder + "\" + $file.Name
            #             $output += "`n tempDbmdfPath: $tempDbmdfPath"
            #             $ourObject | Add-Member -MemberType NoteProperty -Name "Temp Db Mdf Path" -Value $tempDbmdfPath
            #         }
            #     }
            #     else {
            #         if ($file.Name - ".mdf") {
            #             if ($showMDFPath) {
            #                 $mdfpath = $folder + "\" + $file.Name
            #                 $output += "`n MDFPath: $mdfpath"
            #                 $dbNameMDFPath = "" + $file.Name + " Path"
            #                 $ourObject | Add-Member -MemberType NoteProperty -Name $dbNameMDFPath -Value $mdfpath
            #             }
            #             if ($showMDFSize) {
            #                 $mdfsize = ( $file.Length / 1000000 ).ToString() + " MB"
            #                 $output += "`n MDFSize: $mdfsize"
            #                 $dbNameMDFSize = "" + $file.Name + "Size"
            #                 $ourObject | Add-Member -MemberType NoteProperty -Name $dbNameMDFSize -Value $mdfsize
            #             }
            #         }
            #         elseif ($file.Name -match ".ldf") {
            #             if ($showLDFPath) {
            #                 $ldfpath = $folder + "\" + $file.Name
            #                 $output += "`n LDFPath: $ldfpath"
            #                 $dbNameMDFPath = "" + $file.Name + " Path"
            #                 $ourObject | Add-Member -MemberType NoteProperty -Name $dbNameMDFPath -Value $ldfpath
            #             }
            #             if ($showLDFSize) {
            #                 $ldfsize = ( $file.Length / 1000000 ).ToString() + " MB"
            #                 $output += "`n LDFSize: $ldfsize"
            #                 $dbNameMDFSize = "" + $file.Name + " Size"
            #                 $ourObject | Add-Member -MemberType NoteProperty -Name $dbNameMDFSize -Value $ldfsize
            #             }
            #         }
            #     }
            # }
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
       # $filePath = $outputFolder + "/" + $outputFile
       # $output | Out-File -Append $filePath -Encoding UTF8
        #Write-Host "Check the output at File "  $filePath -ForegroundColor Yellow
        return $ourObject
        # return $output | Format-List
    }
}
Get-MachineDetails