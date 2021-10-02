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
"Get SSAS Configuration Details: Windows Server, Windows Version, SSAS Connection Timeout, SSAS Version, SSAS Server Mode, SSAS Edition and other SSAS details."

function Get-SSASConfiguration {
    
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
        $showWindowsVersion = $args[1],
        [Parameter(Mandatory = $false)]
        $showWindowsServer = $args[2],
        [Parameter(Mandatory = $false)]
        $showssasConnectionTimeout = $args[3],
        [Parameter(Mandatory = $false)]
        $showAdministrator = $args[4],
        [Parameter(Mandatory = $false)]
        $showssasVersion = $args[5],
        [Parameter(Mandatory = $false)]
        $showssasVsSqlVersion = $args[6],
        [Parameter(Mandatory = $false)]
        $showssasServerMode = $args[7],
        [Parameter(Mandatory = $false)]
        $showssasCollation = $args[8],
        [Parameter(Mandatory = $false)]
        $showssasCubes = $args[9],
        [Parameter(Mandatory = $false)]
        $showssasEdition = $args[10]
    )

    Begin {
        $output = ""
        $totalspace = 0
       # $outputFolder = "./Output/SSASConfiguration"
      #  $outputFile = "/SSASConfiguration_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".csv"
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
        if (!$showWindowsServer) {
            if (($showWindowsServer -eq 0)) {
                $showWindowsServer = $false
            }
            else {
                $showWindowsServer = $true
            }
        }
        if (!$showssasConnectionTimeout) {
            if (($showssasConnectionTimeout -eq 0)) {
                $showssasConnectionTimeout = $false
            }
            else {
                $showssasConnectionTimeout = $true
            }
        }
        if (!$showAdministrator) {
            if (($showAdministrator -eq 0)) {
                $showAdministrator = $false
            }
            else {
                $showAdministrator = $true
            }
        }
        if (!$showssasVersion) {
            if (($showssasVersion -eq 0)) {
                $showssasVersion = $false
            }
            else {
                $showssasVersion = $true
            }
        }
        if (!$showssasVsSqlVersion) {
            if (($showssasVsSqlVersion -eq 0)) {
                $showssasVsSqlVersion = $false
            }
            else {
                $showssasVsSqlVersion = $true
            }
        }
        if (!$showssasServerMode) {
            if (($showssasServerMode -eq 0)) {
                $showssasServerMode = $false
            }
            else {
                $showssasServerMode = $true
            }
        }
        if (!$showssasCollation) {
            if (($showssasCollation -eq 0)) {
                $showssasCollation = $false
            }
            else {
                $showssasCollation = $true
            }
        }
        if (!$showssasCubes) {
            if (($showssasCubes -eq 0)) {
                $showssasCubes = $false
            }
            else {
                $showssasCubes = $true
            }
        }
        if (!$showssasEdition) {
            if (($showssasEdition -eq 0)) {
                $showssasEdition = $false
            }
            else {
                $showssasEdition = $true
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
       # $erroFile = "./error_log/ssasconfig_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".txt"
        $ourObject = New-Object -TypeName psobject 
        try {
            $WindowsVersion = (systeminfo | Select-String 'OS Version:')[0].ToString().Split(':')[1].Trim()
            $WindowsName = (systeminfo | Select-String 'OS Name:')[0].ToString().Split(':')[1].Trim()
            if ($showWindowsServer) {
                $output += "`n `nWindows Server:" + $env:COMPUTERNAME
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Server" -Value $env:COMPUTERNAME
            }
            if ($showWindowsVersion) {
                $output += "`n `nWindows Details:" + $WindowsName  + " - " + $WindowsVersion 
                $windowsvalue =  ""  + $WindowsName  + " - " + $WindowsVersion 
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Details" -Value $windowsvalue
            }
    
            # $ssasInstanceName = "localhost"
            $loadAssembly = [System.Reflection.Assembly]::LoadWithPartialName("Microsoft.AnalysisServices")
            $svr = New-Object Microsoft.AnalysisServices.Server
            $svr.Connect($serverinstance)
            
            $ssasConnectionTimeout = $svr.ConnectionInfo.ConnectTimeout
            if ($showssasConnectionTimeout) {
                $output = "`n SSAS Connection Timeout: $ssasConnectionTimeout"
                $output = "`n SSAS Server Instance: $serverinstance"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSAS Connection Timeout" -Value $ssasConnectionTimeout
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSAS Server Instance" -Value $serverinstance
            }

            $server = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Server -ArgumentList $serverinstance
            $serverVersion = $server.Information.VersionString
            # To create a new DB
            # $svr.databases.add("SSASDB")
            # $DB = $svr.databases.item("SSASDB")
            # $DB.update()
            # $DB.description = "Testing SSAS DB addition"
            # $DB.update()
    
            $adminQuery = "DECLARE @Names VARCHAR(8000) 
            SELECT @Names = COALESCE(@Names + ', ', '') + name FROM master.sys.server_principals WHERE IS_SRVROLEMEMBER ('sysadmin',name) = 1 ORDER BY name
            select @Names as Name"
            if ($useCredential -eq $true) {
                $admins = (Invoke-Sqlcmd -Query $adminQuery -ServerInstance $serverinstance -User $user -Password $pass).Name
            }
            else {
                $admins = (Invoke-Sqlcmd -Query $adminQuery -ServerInstance $serverinstance).Name
            }
            
            if ($showAdministrator) {
                $output += "`n Administrator: $admins"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Administrator" -Value $admins
            }
            # $output += "`n Roles: $roles"
            $ssasServerMode = $svr.ServerMode
            if ($showssasServerMode) {
                $output += "`nSSAS ServerMode: $ssasServerMode"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSAS ServerMode" -Value $ssasServerMode
            }  
            $ssasVersion = $svr.Version
            if ($showssasVersion) {
                $output += "`nServer Version: $ssasVersion"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Server Version" -Value $ssasVersion
            }
            $ssasEdition = $svr.Edition
            if ($showssasEdition) {
                $output += "`nSSAS Edition: $ssasEdition"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSAS Edition" -Value $ssasEdition
            }
            
            $collationQuery = "use master DECLARE @Names VARCHAR(8000) 
            SELECT @Names = COALESCE(@Names + ', ', '') + (t.name + '_' + c.collation_name)
            FROM sys.schemas s
            INNER JOIN sys.tables t
            ON t.schema_id = s.schema_id
            INNER JOIN sys.columns c
            ON c.object_id = t.object_id
            WHERE collation_name is not null
            select @Names as Name"
            if ($useCredential -eq $true) {
                $ssasCollation = (Invoke-Sqlcmd -Query $collationQuery -ServerInstance $serverinstance -User $user -Password $pass).Name
            }
            else {
                $ssasCollation = (Invoke-Sqlcmd -Query $collationQuery -ServerInstance $serverinstance).Name
            }
            if ($showssasCollation) {
                $output += "`nCollation: $ssasCollation"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Collation" -Value $ssasCollation
            }
            $ssasCubes = $svr.Cubes
            if ($showssasCubes) {
                $output += "`nSSAS Cubes: $ssasCubes"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Cubes" -Value $ssasCubes
            }
            
            if ($showssasVsSqlVersion) {
                $output += "`nSSAS Version: $ssasVersion | ssqlVersion: $serverVersion"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSAS Version Vs SQL Version" -Value "SSAS Version: $ssasVersion | ssqlVersion: $serverVersion"
            }
        }
        catch {
            $err = $_
            $ErrorStackTrace = $_.ScriptStackTrace 
            $ErrorBlock = ($err).ToString() + "`n`nStackTrace: " + ($ErrorStackTrace).ToString()
            #Set-Content -Path $erroFile -Value $ErrorBlock
            "Some error occured check " + $erroFile + " for stacktrace"
            $ourObject | Add-Member -MemberType NoteProperty -Name "Error" -Value $ErrorBlock
        }
    }
    End {
        #$filePath = $outputFolder + "/" + $outputFile
       # $ourObject | Out-File -Append $filePath -Encoding UTF8
       # Write-Host "Check the output at File "  $filePath -ForegroundColor Yellow
        return $ourObject
        # return $output | Format-List
    }
}

Get-SSASConfiguration