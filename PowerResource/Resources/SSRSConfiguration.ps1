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
"Get SSRS Configuration Details: SSRS Connection Timeout, SSRS Instance Name, Version, DB name, Webservice URL, Report Manager URL, Content Manager, Email Settings, Secure Connection,SSRS Database Files and sizes."

function GetParamValue($paramValue) {
    "funinside"
    if (($paramValue -eq 0)) {
        $paramValue = $false
    }
    else {
        $paramValue = $true
    }
    $paramValue
    "END"
    return $paramValue
}
function Get-SSRSConiguration {
    
    Param
    (
        [Parameter(Mandatory = $false)]
        $windowsornetwork = $args[0],
        [Parameter(Mandatory = $false)]
        $serverinstance = $args[1],
        [Parameter(Mandatory = $false)]
        [string]$user = $args[2],
        [Parameter(Mandatory = $false)]
        [string]$pass = $args[3],
        [Parameter(Mandatory = $false)]
        $showWindowsServer = $args[4],
        [Parameter(Mandatory = $false)]
        $showWindowsVersion = $args[5],
        [Parameter(Mandatory = $false)]
        $showssrsConnectionTimeout = $args[6],
        [Parameter(Mandatory = $false)]
        $showServiceMode = $args[7],
        [Parameter(Mandatory = $false)]
        $showDatabaseName = $args[8],
        [Parameter(Mandatory = $false)]
        $showDatabaseServerName = $args[9],
        [Parameter(Mandatory = $false)]
        $showssrsInstanceName = $args[10],
        [Parameter(Mandatory = $false)]
        $showssrsVsSqlVersion = $args[11],
        [Parameter(Mandatory = $false)]
        $showWebPortalUrl = $args[12],
        [Parameter(Mandatory = $false)]
        $showcontentManagers = $args[13],
        [Parameter(Mandatory = $false)]
        $showreportManagerUrl = $args[14],
        [Parameter(Mandatory = $false)]
        $showSecureConnectionLevel = $args[15],
        [Parameter(Mandatory = $false)]
        $showSenderEmailAddress = $args[16],
        [Parameter(Mandatory = $false)]
        $showexecAccount = $args[17],

        [Parameter(Mandatory = $false)]
        $showssrsDBmdfPath = $args[18],
        [Parameter(Mandatory = $false)]
        $showssrsDBmdfSize = $args[19],
        [Parameter(Mandatory = $false)]
        $showssrsDBldfPath = $args[20],
        [Parameter(Mandatory = $false)]
        $showssrsDBldfSize = $args[21],

        [Parameter(Mandatory = $false)]
        $showssrsTempDBmdfPath = $args[22],
        [Parameter(Mandatory = $false)]
        $showssrsTempDBmdfSize = $args[23],
        [Parameter(Mandatory = $false)]
        $showssrsTempDBldfPath = $args[24],
        [Parameter(Mandatory = $false)]
        $showssrsTempDBldfSize = $args[25]
    )

    Begin {
        $output = ""
        # $outputFolder = "./Output/SSRSConfiguration"
        # $outputFile = "/SSRSConfiguration_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".csv"
       
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
        $folderName = "/"
        if (!$showWindowsServer) {
            if (($showWindowsServer -eq 0)) {
                $showWindowsServer = $false
            }
            else {
                $showWindowsServer = $true
            }
        }
        if (!$showWindowsVersion) {
            if (($showWindowsVersion -eq 0)) {
                $showWindowsVersion = $false
            }
            else {
                $showWindowsVersion = $true
            }
        }
        if (!$showssrsConnectionTimeout) {
            if (($showssrsConnectionTimeout -eq 0)) {
                $showssrsConnectionTimeout = $false
            }
            else {
                $showssrsConnectionTimeout = $true
            }
        }

        if (!$showServiceMode) {
            if (($showServiceMode -eq 0)) {
                $showServiceMode = $false
            }
            else {
                $showServiceMode = $true
            }
        }
        if (!$showDatabaseName) {
            if (($showDatabaseName -eq 0)) {
                $showDatabaseName = $false
            }
            else {
                $showDatabaseName = $true
            }
        }
        if (!$showDatabaseServerName) {
            if (($showDatabaseServerName -eq 0)) {
                $showDatabaseServerName = $false
            }
            else {
                $showDatabaseServerName = $true
            }
        }

        if (!$showssrsInstanceName) {
            if (($showssrsInstanceName -eq 0)) {
                $showssrsInstanceName = $false
            }
            else {
                $showssrsInstanceName = $true
            }
        }
        if (!$showssrsVsSqlVersion) {
            if (($showssrsVsSqlVersion -eq 0)) {
                $showssrsVsSqlVersion = $false
            }
            else {
                $showssrsVsSqlVersion = $true
            }
        }
        if (!$showWebPortalUrl) {
            if (($showWebPortalUrl -eq 0)) {
                $showWebPortalUrl = $false
            }
            else {
                $showWebPortalUrl = $true
            }
        }
        if (!$showcontentManagers) {
            if (($showcontentManagers -eq 0)) {
                $showcontentManagers = $false
            }
            else {
                $showcontentManagers = $true
            }
        }
        if (!$showreportManagerUrl) {
            if (($showreportManagerUrl -eq 0)) {
                $showreportManagerUrl = $false
            }
            else {
                $showreportManagerUrl = $true
            }
        }
        if (!$showSecureConnectionLevel) {
            if (($showSecureConnectionLevel -eq 0)) {
                $showSecureConnectionLevel = $false
            }
            else {
                $showSecureConnectionLevel = $true
            }
        }
        if (!$showSenderEmailAddress) {
            if (($showSenderEmailAddress -eq 0)) {
                $showSenderEmailAddress = $false
            }
            else {
                $showSenderEmailAddress = $true
            }
        }
        if (!$showexecAccount) {
            if (($showexecAccount -eq 0)) {
                $showexecAccount = $false
            }
            else {
                $showexecAccount = $true
            }
        }
        if (!$showssrsDBmdfPath) {
            if (($showssrsDBmdfPath -eq 0)) {
                $showssrsDBmdfPath = $false
            }
            else {
                $showssrsDBmdfPath = $true
            }
        }
        if (!$showssrsDBmdfSize) {
            if (($showssrsDBmdfSize -eq 0)) {
                $showssrsDBmdfSize = $false
            }
            else {
                $showssrsDBmdfSize = $true
            }
        }
        if (!$showssrsDBldfPath) {
            if (($showssrsDBldfPath -eq 0)) {
                $showssrsDBldfPath = $false
            }
            else {
                $showssrsDBldfPath = $true
            }
        }
        if (!$showssrsDBldfSize) {
            if (($showssrsDBldfSize -eq 0)) {
                $showssrsDBldfSize = $false
            }
            else {
                $showssrsDBldfSize = $true
            }
        }
        if (!$showssrsTempDBmdfPath) {
            if (($showssrsTempDBmdfPath -eq 0)) {
                $showssrsTempDBmdfPath = $false
            }
            else {
                $showssrsTempDBmdfPath = $true
            }
        }
        if (!$showssrsTempDBmdfSize) {
            if (($showssrsTempDBmdfSize -eq 0)) {
                $showssrsTempDBmdfSize = $false
            }
            else {
                $showssrsTempDBmdfSize = $true
            }
        }
        if (!$showssrsTempDBldfPath) {
            if (($showssrsTempDBldfPath -eq 0)) {
                $showssrsTempDBldfPath = $false
            }
            else {
                $showssrsTempDBldfPath = $true
            }
        }
        if (!$showssrsTempDBldfSize) {
            if (($showssrsTempDBldfSize -eq 0)) {
                $showssrsTempDBldfSize = $false
            }
            else {
                $showssrsTempDBldfSize = $true
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
        $servername = $env:COMPUTERNAME
       
        #$erroFile = "./error_log/ssrsconfig_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".txt"
        $ourObject = New-Object -TypeName psobject 
        #$ourObject | Add-Member -MemberType NoteProperty -Name "Connection" -Value $windowsornetwork
        #$userValue = "User"+ $user + "Value has space"
        #$passValue = "Pass"+ $pass + "Value has space"
        #$ourObject | Add-Member -MemberType NoteProperty -Name "User" -Value $userValue
        #$ourObject | Add-Member -MemberType NoteProperty -Name "Password" -Value $passValue
        try {
            $server = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Server -ArgumentList $serverinstance
            $serverVersion = $server.Information.VersionString
            $folder = $server.Information.MasterDBLogPath
           
            if ($showWindowsServer) {
                $output += "`n Windows Server:" + $servername
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Server" -Value $servername
            }

            $WindowsVersion = (systeminfo | Select-String 'OS Version:')[0].ToString().Split(':')[1].Trim()
            $WindowsName = (systeminfo | Select-String 'OS Name:')[0].ToString().Split(':')[1].Trim()
            if ($showWindowsVersion) {
                $output += "`n `nWindows Details:" + $WindowsName  + " - " + $WindowsVersion 
                $windowsvalue =  ""  + $WindowsName  + " - " + $WindowsVersion 
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Details" -Value $windowsvalue
            }
            # SELECT * FROM dbo.ConfigurationInfo where Name like '%timeout%'
            if ($useCredential -eq $true) {
                $ssrsConnectionTimeout = (Invoke-Sqlcmd -Query "SELECT Value FROM [ReportServer].[dbo].ConfigurationInfo where Name = 'SessionTimeout'" -ServerInstance $serverinstance -User $user -Password $pass) | Select-Object -ExpandProperty Value
            }
            else {
                $ssrsConnectionTimeout = (Invoke-Sqlcmd -Query "SELECT Value FROM [ReportServer].[dbo].ConfigurationInfo where Name = 'SessionTimeout'" -ServerInstance $serverinstance) | Select-Object -ExpandProperty Value
            }
            if ($showssrsConnectionTimeout) {
                $output += "`n ssrsConnectionTimeout: $ssrsConnectionTimeout"
                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Connection Timeout" -Value $ssrsConnectionTimeout
            }
            if ($useCredential -eq $true) {
                $serverVersion = (Invoke-Sqlcmd -Query "select version_major from msdb.dbo.msdb_version" -ServerInstance $serverinstance -User $user -Password $pass) | Select-Object -ExpandProperty version_major
            }
            else {
                $serverVersion = (Invoke-Sqlcmd -Query "select version_major from msdb.dbo.msdb_version" -ServerInstance $serverinstance) | Select-Object -ExpandProperty version_major
            }

            $rs = (Get-WmiObject -namespace root\Microsoft\SqlServer\ReportServer  -class __Namespace) | Select-Object -ExpandProperty Name
            $nspace = "root\Microsoft\SQLServer\ReportServer\$rs\v$serverVersion\Admin"
            $RSServers = Get-WmiObject -Namespace $nspace -class MSReportServer_ConfigurationSetting -ComputerName $servername -ErrorVariable perror -ErrorAction SilentlyContinue
            foreach ($r in $RSServers) {
                $folder = $server.Information.MasterDBLogPath
    
                $ssrsInstanceName = $r.InstanceName
                if ($showssrsInstanceName) {
                    $output += "`n ReportServer InstanceName: $ssrsInstanceName"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "ReportServer InstanceName" -Value $ssrsInstanceName
                }
                
                $ssrsVers = $r.version
                if ($showssrsVsSqlVersion) {
                    $output += "`n SSRS Version: $ssrsVers; SQL Version: $serverVersion"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Version" -Value $ssrsVers
                    $ourObject | Add-Member -MemberType NoteProperty -Name "SQL Version" -Value $serverVersion
                }
                if ($showServiceMode) {
                    if ($r.IsSharePointIntegrated -eq $false) {
                        $output += "`n Service Mode: Native"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "Service Mode" -Value "Native"
                    }
                    else {
                        $output += "`n Service Mode: Sharepoint"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "Service Mode" -Value "Sharepoint"
                    }
                }
                $ssrsDB = $r.DatabaseName
                if ($showDatabaseName) {
                    $output += "`n Database : $ssrsDB"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Database" -Value $ssrsDB
                }
                if ($showDatabaseServerName) {
                    $output += "`n Database Location: " + $r.DatabaseServerName
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Database Location" -Value $r.DatabaseServerName
                }
                $vPath = $r.VirtualDirectoryReportServer
                $urls = $r.ListReservedUrls()
                $urls = $urls.UrlString[0]
                $WebPortalUrl = $urls.Replace('+', $servername) + "/$vPath"
                if ($showWebPortalUrl) {
                    $output += "`n WEB Service URL: $WebPortalUrl"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "WEB Service URL" -Value $WebPortalUrl
                }
                $ReportServerUri = $WebPortalUrl + "/ReportService2010.asmx"
                $InheritParent = $true

                $rsProxy = New-WebServiceProxy -Uri $ReportServerUri -UseDefaultCredential
                $items = $rsProxy.GetPolicies($folderName, [ref]$InheritParent)
                $contentManagers = ""
                foreach ($item in $items) {
                    if ($item.Roles.Name -eq "Content Manager") {
                        $contentManagers += $item.GroupUserName + ","
                    }
                }
                if ($showcontentManagers) {
                    $output += "`n Content Managers: $contentManagers"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Content Managers" -Value $contentManagers
                }
    
                if ($r.VirtualDirectoryReportManager -ne "") {
                    $reportManagerUrl = $urls.Replace('+', $servername) + "/" + $r.VirtualDirectoryReportManager
                }
                else {
                    $reportManagerUrl = $urls.Replace('+', $servername) + "/Reports"
                }
                if ($showreportManagerUrl) {
                    $output += "`n Report Manager URL: $reportManagerUrl"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Report Manager URL" -Value $reportManagerUrl
                }
                $SecureConnectionLevel = $r.SecureConnectionLevel
                if ($showSecureConnectionLevel) {
                    $output += "`n Secure Connection Level: $SecureConnectionLevel"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Secure Connection Level" -Value $SecureConnectionLevel
                }
                $SenderEmailAddress = $r.SenderEmailAddress
                if ($showSenderEmailAddress) {
                    if ($SenderEmailAddress -ne "") {
                        $output += "`n E-Mail Setting: $SenderEmailAddress"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "E-Mail Setting" -Value $SenderEmailAddress
                    }
                    else {
                        $output += "`n E-Mail Setting: N/A"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "E-Mail Setting" -Value "N/A"
                    }
                }
                if ($showexecAccount) {
                    $execAccount = $r.UnattendedExecutionAccount
                    if ($execAccount -ne "") {
                        $output += "`n Execution Account: $execAccount"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Execution Account" -Value $execAccount
                    }
                    else {
                        $output += "`n SSRS Excution account is not configured"
                        $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Execution Account" -Value "Not Configured"
                    }
                }
                $ssrsDBmdfPath = $folder + "\" + $ssrsDB + ".mdf"
                
                $mdfldfsizeQuery = "SELECT DB_NAME(database_id) AS dbName, 
                CASE WHEN type_desc = 'ROWS' THEN 'MDF' ELSE 'LDF' END as FileType, 
                name AS FileName, 
                size/128.0 AS FileSize,
                s.physical_name as FilePath
            FROM sys.master_files s
            WHERE  type IN (0,1) and name LIKE 'ReportServer%'"

                if ($useCredential -eq $true) {
                    $reportServerRecords = (Invoke-Sqlcmd -Query $mdfldfsizeQuery -ServerInstance $serverinstance -User $user -Password $pass)
                }
                else {
                    $reportServerRecords = (Invoke-Sqlcmd -Query $mdfldfsizeQuery -ServerInstance $serverinstance)
                }

                foreach ($item in $reportServerRecords) {
                    if ($item.dbName -eq "ReportServer") {
                        if ($item.FileType -eq "MDF") {
                            if ($showssrsDBmdfPath) {
                                $output += "`n SSRS DB MDF Path: " + $item.FilePath
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS DB MDF Path" -Value $item.FilePath
                            }
                            if ($showssrsDBmdfSize) {
                                $output += "`n SSRS DB MDF Size: " + $item.FileSize + " MB"
                                $dbMdfSize = "" + $item.FileSize + " MB"
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS DB MDF Size" -Value $dbMdfSize
                            }
                        }
                        if ($item.FileType -eq "LDF") {
                            if ($showssrsDBldfPath) {
                                $output += "`n SSRS DB LDF Path: " + $item.FilePath
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS DB LDF Path" -Value $item.FilePath
                            }
                            if ($showssrsDBldfSize) {
                                $output += "`n SSRS DB LDF Size: " + $item.FileSize + " MB"
                                $dbLdfSize = "" + $item.FileSize + " MB"
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS DB LDF Size" -Value $dbLdfSize
                            }
                        }
                    }
                    if ($item.dbName -eq "ReportServerTempDB") {
                        if ($item.FileType -eq "MDF") {
                            if ($showssrsTempDBmdfPath) {
                                $output += "`n SSRS Temp DB MDF Path: " + $item.FilePath
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Temp DB MDF Path" -Value $item.FilePath
                            }
                            if ($showssrsTempDBmdfSize) {
                                $output += "`n SSRS Temp DB MDF Size: "+ $item.FileSize + " MB"
                                $tempMdfSize = "" + $item.FileSize + " MB"
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Temp DB MDF Size" -Value $tempMdfSize
                            }
                        }
                        if ($item.FileType -eq "LDF") {
                            if ($showssrsTempDBldfPath) {
                                $output += "`n SSRS Temp DB LDF Path: " + $item.FilePath
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Temp DB LDF Path" -Value $item.FilePath
                            }
                            if ($showssrsTempDBldfSize) {
                                $output += "`n SSRS Temp DB LDF Size: "+ $item.FileSize + " MB"
                                $tempLdfSize = "" + $item.FileSize + " MB"
                                $ourObject | Add-Member -MemberType NoteProperty -Name "SSRS Temp DB LDF Size" -Value $tempLdfSize
                            }
                        }
                    }
                }
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
        #$ourObject | Out-File -Append $filePath -Encoding UTF8
        #Write-Host "Check the output at File "  $filePath -ForegroundColor Yellow
        return $ourObject
        # return $output | Format-List
    }
}

Get-SSRSConiguration