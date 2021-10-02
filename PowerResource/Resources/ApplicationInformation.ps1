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
"Get Application Information "

function Get-ApplicationInformation {
        Param
    (
        [Parameter(Mandatory = $false)]
        [string]$HostName = $args[0],
        [Parameter(Mandatory = $false)]
        $port = $args[1],
        [Parameter(Mandatory = $false)]
        $windowsornetwork = $args[2],
        [Parameter(Mandatory = $false)]
        $serverinstance = $args[3],
        [Parameter(Mandatory = $false)]
        [string]$user = $args[4],
        [Parameter(Mandatory = $false)]
        [string]$pass = $args[5],
        [Parameter(Mandatory = $false)]
        $showtotalCpuCount = $args[6],
        [Parameter(Mandatory = $false)]
        $showUpdateDateObject = $args[7],
        [Parameter(Mandatory = $false)]
        $showCPUDetails = $args[8],
        [Parameter(Mandatory = $false)]
        $showNZISService = $args[9],
        [Parameter(Mandatory = $false)]
        $showNZTaskService = $args[10],
        [Parameter(Mandatory = $false)]
        $showServerName = $args[11],
        [Parameter(Mandatory = $false)]
        $showRam = $args[12],
        [Parameter(Mandatory = $false)]
        $showWindowsVersion = $args[13],
        [Parameter(Mandatory = $false)]
        $showis64BitOS = $args[14],
        [Parameter(Mandatory = $false)]
        $showis64BitProcess = $args[15],
        [Parameter(Mandatory = $false)]
        $showdomain = $args[16],
        [Parameter(Mandatory = $false)]
        $showconnectionTimeout = $args[17],
        [Parameter(Mandatory = $false)]
        $showssl2 = $args[18],
        [Parameter(Mandatory = $false)]
        $showssl3 = $args[19],
        [Parameter(Mandatory = $false)]
        $showtls = $args[20],
        [Parameter(Mandatory = $false)]
        $showtls11 = $args[21],
        [Parameter(Mandatory = $false)]
        $showtls12 = $args[22],
        [Parameter(Mandatory = $false)]
        $showssslv2 = $args[23],
        [Parameter(Mandatory = $false)]
        $showssslv3 = $args[24],
        [Parameter(Mandatory = $false)]
        $showstlsv11 = $args[25],
        [Parameter(Mandatory = $false)]
        $showstlsv12 = $args[26],
        [Parameter(Mandatory = $false)]
        $showstlsv10 = $args[27]
    )

    Begin {
        $output = ""
        $totalspace = 0
        #$outputFolder = "./Output/Application"
        #$outputFile = "/Application_" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".csv"
        # If (!(Test-Path $outputFolder)) {
        #     New-Item -Path $outputFolder -ItemType Directory
        # }
        # If (!(Test-Path "./error_log")) {
        #     New-Item -Path "./error_log" -ItemType Directory
        # }
        try {
            Import-Module SqlServer 
           # Import-Module SQLPS 
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
        if (!$showtotalCpuCount) {
            if (($showtotalCpuCount -eq 0)) {
                $showtotalCpuCount = $false
            } else {
                $showtotalCpuCount = $true
            }
        }
        if (!$showUpdateDateObject) {
            if (($showUpdateDateObject -eq 0)) {
                $showUpdateDateObject = $false
            } else {
                $showUpdateDateObject = $true
            }
        }
        if (!$showCPUDetails) {
            if (($showCPUDetails -eq 0)) {
                $showCPUDetails = $false
            } else {
                $showCPUDetails = $true
            }
        }
        if (!$showNZISService) {
            if (($showNZISService -eq 0)) {
                $showNZISService = $false
            } else {
                $showNZISService = $true
            }
        }
        if (!$showNZTaskService) {
            if (($showNZTaskService -eq 0)) {
                $showNZTaskService = $false
            } else {
                $showNZTaskService = $true
            }
        }
        if (!$showServerName) {
            if (($showServerName -eq 0)) {
                $showServerName = $false
            } else {
                $showServerName = $true
            }
        }
        if (!$showRam) {
            if (($showRam -eq 0)) {
                $showRam = $false
            } else {
                $showRam = $true
            }
        }
        if (!$showWindowsVersion) {
            if (($showWindowsVersion -eq 0)) {
                $showWindowsVersion = $false
            } else {
                $showWindowsVersion = $true
            }
        }
        if (!$showis64BitOS) {
            if (($showis64BitOS -eq 0)) {
                $showis64BitOS = $false
            } else {
                $showis64BitOS = $true
            }
        }
        if (!$showis64BitProcess) {
            if (($showis64BitProcess -eq 0)) {
                $showis64BitProcess = $false
            } else {
                $showis64BitProcess = $true
            }
        }
        if (!$showdomain) {
            if (($showdomain -eq 0)) {
                $showdomain = $false
            } else {
                $showdomain = $true
            }
        }
        if (!$showconnectionTimeout) {
            if (($showconnectionTimeout -eq 0)) {
                $showconnectionTimeout = $false
            } else {
                $showconnectionTimeout = $true
            }
        }
        if (!$showssl2) {
            if (($showssl2 -eq 0)) {
                $showssl2 = $false
            } else {
                $showssl2 = $true
            }
        }
        if (!$showssl3) {
            if (($showssl3 -eq 0)) {
                $showssl3 = $false
            } else {
                $showssl3 = $true
            }
        }
        if (!$showtls) {
            if (($showtls -eq 0)) {
                $showtls = $false
            } else {
                $showtls = $true
            }
        }

        if (!$showtls11) {
            if (($showtls11 -eq 0)) {
                $showtls11 = $false
            } else {
                $showtls11 = $true
            }
        }
        if (!$showtls12) {
            if (($showtls12 -eq 0)) {
                $showtls12 = $false
            } else {
                $showtls12 = $true
            }
        }
        if (!$showssslv2) {
            if (($showssslv2 -eq 0)) {
                $showssslv2 = $false
            } else {
                $showssslv2 = $true
            }
        }
        if (!$showssslv3) {
            if (($showssslv3 -eq 0)) {
                $showssslv3 = $false
            } else {
                $showssslv3 = $true
            }
        }
        if (!$showstlsv11) {
            if (($showstlsv11 -eq 0)) {
                $showstlsv11 = $false
            } else {
                $showstlsv11 = $true
            }
        }
        if (!$showstlsv12) {
            if (($showstlsv12 -eq 0)) {
                $showstlsv12 = $false
            } else {
                $showstlsv12 = $true
            }
        }
        if (!$showstlsv10) {
            if (($showstlsv10 -eq 0)) {
                $showstlsv10 = $false
            } else {
                $showstlsv10 = $true
            }
        }
        $useCredential = $true
        if ($windowsornetwork -eq " ") {
            $windowsornetwork = "w"
        }
        if (($windowsornetwork -eq "windows") -or ($windowsornetwork -eq "w")) {
            $useCredential = $false
        } else {
            $useCredential = $true
            if ($user -and $pass) {
                $password = ConvertTo-SecureString $pass -AsPlainText -Force
                $pccred = New-Object System.Management.Automation.PSCredential ($user, $password )
            }
        }
    }
    Process {
        #$erroFile = "./error_log/application" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString()
        $ourObject = New-Object -TypeName psobject 
        
        try {
            if ($port -eq "") {
                $port = 443
            }
            if ($port -eq "localhost"){
                $port = 80
            }
            $CPUCore = (Get-CIMInstance -Class 'CIM_Processor').NumberOfCores
            $UpdateDateObject = ((New-Object -com "Microsoft.Update.AutoUpdate").Results | select -Property LastInstallationSuccessDate).LastInstallationSuccessDate
            $RAM = (systeminfo | Select-String 'Total Physical Memory:').ToString().Split(':')[1].Trim()
            $ServerName = $env:COMPUTERNAME
            $drives = Get-WmiObject Win32_LogicalDisk -ComputerName $ServerName | Select -Property Size
            foreach ($drive  in $drives) {
                $drivename = $drive. -split ":"
                if (($drivename -ne "A") -and ($drivename -ne "B")) {
                    $totalspace += [int]($drive.Size / 1GB)
                }
                #if ($drivename -eq "C") {
                #    $cspace = "" + ($drive.Size / 1GB) + " GB"
                #    $ourObject | Add-Member -MemberType NoteProperty -Name "C Drive Space" -Value $cspace
               # }
            }
             if($UpdateDateObject -eq "01/01/1601"){
                $UpdateDateObject = "N/A"
            }

            if ($useCredential -eq $true) {
                $totalCpuCount = ( Invoke-Sqlcmd -Query "SELECT i.cpu_count from sys.dm_os_sys_info i" -ServerInstance $serverinstance -User $user -Password $pass).cpu_count
            } else {
                $totalCpuCount = ( Invoke-Sqlcmd -Query "SELECT i.cpu_count from sys.dm_os_sys_info i" -ServerInstance $serverinstance).cpu_count
            }
            $WindowsVersion = (systeminfo | Select-String 'OS Version:')[0].ToString().Split(':')[1].Trim()
            $WindowsName = (systeminfo | Select-String 'OS Name:')[0].ToString().Split(':')[1].Trim()
            $is64BitOS = [System.Environment]::Is64BitOperatingSystem
            $is64BitProcess = [System.Environment]::Is64BitProcess
            $NZISService = Get-Service | Where-Object { $_.Name -eq "NZ IS Scheduler Service" }
            $NZTaskService = Get-Service | Where-Object { $_.Name -eq "NZ Task Scheduler Service" }
            $domain = (Get-WmiObject Win32_ComputerSystem).Domain
    
            $RAMGB = [int]($RAM.Split(' ')[0].Trim() / 1024) 
          
            if ($useCredential -eq $true) {
                $connectionTimeout = ( Invoke-Sqlcmd -Query "sp_configure 'Remote Query Timeout'" -ServerInstance $serverinstance -User $user -Password $pass).config_value
            } else {
                $connectionTimeout = ( Invoke-Sqlcmd -Query "sp_configure 'Remote Query Timeout'").config_value
            }
            
            $enabledProtocols = [enum]::GetNames([Net.SecurityProtocolType])
            $ssl2 = "Disabled"
            $ssl3 = "Disabled"
            $tls = "Disabled"
            $tls11 = "Disabled"
            $tls12 = "Disabled"
            if ($enabledProtocols -contains 'Ssl2') {
                $ssl2 = "Enabled"
            }
    
            if ($enabledProtocols -contains 'Ssl3') {
                $ssl3 = "Enabled"
            }
            if ($enabledProtocols -contains 'Tls') {
                $tls = "Enabled"
            }
            if ($enabledProtocols -contains 'Tls11') {
                $tls11 = "Enabled"
            } 
            if ($enabledProtocols -contains 'Tls12') {
                $tls12 = "Enabled"
            } 
           

            #$erroFile = "./error_log/applicationserverssl" + (get-date -f MM_dd_yyyy_HH_mm_ss).ToString() + ".txt"

            $RetValue = New-Object psobject -Property @{
                Host          = $HostName
                Port          = $port
                SSLv2         = $false
                SSLv3         = $false
                TLSv1_0       = $false
                TLSv1_1       = $false
                TLSv1_2       = $false
                KeyExhange    = $null
                HashAlgorithm = $null
            }
            "ssl2", "ssl3", "tls", "tls11", "tls12" | % {
                $TcpClient = New-Object Net.Sockets.TcpClient
                $TcpClient.Connect($RetValue.Host, [int]$RetValue.Port)
                $SslStream = New-Object Net.Security.SslStream $TcpClient.GetStream()
                $SslStream.ReadTimeout = 15000
                $SslStream.WriteTimeout = 15000
                try {
                    $SslStream.AuthenticateAsClient($RetValue.Host, $null, $_, $false)
                    $RetValue.KeyExhange = $SslStream.KeyExchangeAlgorithm
                    $RetValue.HashAlgorithm = $SslStream.HashAlgorithm
                    $status = $true
                }
                catch {
                    $status = $false
                }
                switch ($_) {
                    "ssl2" { $RetValue.SSLv2 = $status }    
                    "ssl3" { $RetValue.SSLv3 = $status }    
                    "tls" { $RetValue.TLSv1_0 = $status }    
                    "tls11" { $RetValue.TLSv1_1 = $status }    
                    "tls12" { $RetValue.TLSv1_2 = $status }    
                }
    
            }
            $ssslv2 = If ($RetValue.SSLv2) { "Enabled" } Else { "Disabled" }
            $ssslv3 = If ($RetValue.SSLv3) { "Enabled" } Else { "Disabled" }
            $stlsv10 = If ($RetValue.TLSv1_0) { "Enabled" } Else { "Disabled" }
            $stlsv11 = If ($RetValue.TLSv1_1) { "Enabled" } Else { "Disabled" }
            $stlsv12 = If ($RetValue.TLSv1_2 ) { "Enabled" } Else { "Disabled" }

           
            if ($showUpdateDateObject) {
                $output += "`nLast Update Dates $UpdateDateObject"
                $cultureID = (Get-Culture | Select -Property LCID).LCID
                $dateFormat = [System.Globalization.CultureInfo]::GetCultureInfo($cultureID).DateTimeFormat.ShortDatePattern
                $ourObject | Add-Member -MemberType NoteProperty -Name "Last Update Date" -Value $UpdateDateObject
                $ourObject | Add-Member -MemberType NoteProperty -Name "Date Format" -Value $dateFormat
            }
            if ($showNZISService) {
                if ($NZISService) {
                    $output += "`nWindows Service [NZ IS Scheduler Service]:" + $NZISService.Status
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Service [NZ IS Scheduler Service]" -Value $NZISService.Status
                } else {
                    $output += "`nWindows Service [NZ IS Scheduler Service]: Not Found"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Service [NZ IS Scheduler Service]" -Value "Not Found"
                }
            }
            if ($showNZTaskService) {
                if ($NZTaskService) {
                    $output += "`nWindows Service [NZ Task Scheduler Service]:" + $NZTaskService.Status
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Service [NZ Task Scheduler Service]" -Value $NZTaskService.Status
                } else {
                    $output += "`nWindows Service [NZ Task Scheduler Service]: Not Found"
                    $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Service [NZ Task Scheduler Service]" -Value "Not Found"
                }
            }
            if ($showServerName) {
                $output += "`nWindows Sever:" + $ServerName
                $output += "`nWorkstation Name: " + $ServerName
                $serverModel = (get-wmiobject win32_computersystem | Select -Property Model).Model
                if (($serverModel -like "irtual") -or ($serverModel -like "VM") ) {
                    $serverType = "Virtual"
                } else {
                    $serverType = "Physical"
                }
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Sever" -Value $ServerName
                $ourObject | Add-Member -MemberType NoteProperty -Name "Workstation Name" -Value $ServerName
                $ourObject | Add-Member -MemberType NoteProperty -Name "Server Type" -Value $serverType
            }
            if ($showWindowsVersion) {
                $output += "`n `nWindows Details:" + $WindowsName  + " - " + $WindowsVersion 
                $windowsvalue =  ""  + $WindowsName  + " - " + $WindowsVersion 
                $ourObject | Add-Member -MemberType NoteProperty -Name "Windows Details" -Value $windowsvalue
            }
            if ($showtotalCpuCount) {
                $output += "`nTotal CPU Count $totalCpuCount"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Total CPU Count" -Value $totalCpuCount
            }
            if ($showis64BitOS) {
                $output += "`nIs 64 Bit OS:" + $is64BitOS
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is 64 Bit OS" -Value $is64BitOS
            }
            if ($showis64BitProcess) {
                $output += "`nIs 64 Bit Process:" + $is64BitProcess
                $ourObject | Add-Member -MemberType NoteProperty -Name "Is 64 Bit Process" -Value $is64BitProcess
            }
            if ($showdomain) {
                $output += "`nDomain:" + $domain
                $ourObject | Add-Member -MemberType NoteProperty -Name "Domain" -Value $domain
            }
            if ($showRam) {
                $output += "`nTotal Physical Memory:" + $RAMGB + " GB"
                $ramvalue = "" + $RAMGB + " GB"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Total Physical Memory" -Value $ramvalue
            }

            $output += "`n================================================"
            $output += "`nClient Security Protocols"
            $output += "`n================================================"
            if ($showssl2) {
                $output += "`nSecurity [Client SSL 2.0] Is Client SSL 2.0 is " + $ssl2
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Client SSL 2.0] Is Client SSL 2.0 is " -Value $ssl2
            }
            if ($showssl3) {
                $output += "`nSecurity [Client SSL 3.0] Is Client SSL 3.0 is " + $ssl3
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Client SSL 3.0] Is Client SSL 3.0 is " -Value $ssl3
            }
            if ($showtls) {
                $output += "`nSecurity [Client TLS 1.0] Is Client TLS 1.0 is " + $tls
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Client TLS 1.0] Is Client TLS 1.0 is " -Value $tls
            }
            if ($showtls11) {
                $output += "`nSecurity [Client TLS 1.1] Is Client TLS 1.1 is " + $tls11
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Client TLS 1.1] Is Client TLS 1.1 is " -Value $tls11
            }
            if ($showtls12) {
                $output += "`nSecurity [Client TLS 1.2] Is Client TLS 1.2 is " + $tls12
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Client TLS 1.2] Is Client TLS 1.2 is  " -Value $tls12
            }
            $output += "`n================================================"
            $output += "`n================================================"
            $output += "`nServer Security Protocols"
            $output += "`n================================================"
            if ($showssslv2) {
                $output += "`nSecurity [Server SSL 2.0] Is Client SSL 2.0 is " + $ssslv2
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Server SSL 2.0] Is Client SSL 2.0 is  " -Value $ssslv2
            }
            if ($showssslv3) {
                $output += "`nSecurity [Server SSL 3.0] Is Client SSL 3.0 is " + $ssslv3
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Server SSL 3.0] Is Client SSL 3.0 is  " -Value $ssslv3
            }
            if ($showstlsv10) {
                $output += "`nSecurity [Server TLS 1.0] Is Client TLS 1.0 is " + $stlsv10
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Server TLS 1.0] Is Client TLS 1.0 is  " -Value $stlsv10
            }
            if ($showstlsv11) {
                $output += "`nSecurity [Server TLS 1.1] Is Client TLS 1.1 is " + $stlsv11 
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Server TLS 1.1] Is Client TLS 1.1 is  " -Value $stlsv11
            }
            if ($showstlsv12) {
                $output += "`nSecurity [Server TLS 1.2] Is Client TLS 1.2 is " + $stlsv12
                $ourObject | Add-Member -MemberType NoteProperty -Name "Security [Server TLS 1.2] Is Client TLS 1.2 is  " -Value $stlsv12
            }
            $output += "`n================================================"

            if ($showconnectionTimeout){
                $output += "`nSql Server Connection Timeout: $connectionTimeout"
                $ourObject | Add-Member -MemberType NoteProperty -Name "Sql Server Connection Timeout  " -Value $connectionTimeout
            }
            if ($showCPUDetails) {
                $output += "`CPU Details : CPUCore=" + $CPUCore + ",RAM=" + $RAMGB + " GB,DISK=" + $totalspace + " GB"
				$recommendValue = "CPUCore=" + $CPUCore + ",RAM=" + $RAMGB + " GB,DISK=" + $totalspace + " GB"
                $ourObject | Add-Member -MemberType NoteProperty -Name "CPU Details " -Value $recommendValue
            }

        }
        catch {
            $err = $_
            $ErrorStackTrace = $_.ScriptStackTrace 
            $ErrorBlock = ($err).ToString() + "`n`nStackTrace: " + ($ErrorStackTrace).ToString()
            $ErrorBlock += "`n`nCaught an exception:"
            $ErrorBlock += "`nException type: $($_.Exception.GetType().FullName)"
            $ErrorBlock += "`nException message: $($_.Exception.Message)" 
            $ErrorBlock += "`nError: $($_.Exception)" 
            #Set-Content -Path $erroFile -Value $ErrorBlock
            #"Some error occured check " + $erroFile + " for stacktrace " 
            $ourObject | Add-Member -MemberType NoteProperty -Name "Error" -Value $ErrorBlock
        }
       
    }
    End {
        #$filePath = $outputFolder + "/" + $outputFile
       # $ourObject | Out-File -Append $filePath -Encoding UTF8
        #Write-Host "Check the output at File "  $filePath -ForegroundColor Yellow
        return $ourObject
        # return $output | Format-List
    }
}

Get-ApplicationInformation