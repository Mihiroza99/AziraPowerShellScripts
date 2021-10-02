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
"Workstation Error Log"
function ConvertTo-ScriptBlock {
    param ([string]$string)
    $scriptblock = $executioncontext.invokecommand.NewScriptBlock($string)
    return $scriptblock
 }
function Get-SqlErrorLog {
    
    Param
    (
        [Parameter(Mandatory = $false)]
        [string]$sourcefilter = $args[0],
        [Parameter(Mandatory = $false)]
        [string]$messagefilter = $args[1]
    )

    Begin {
        $output = ""
        if ($sourcefilter -eq " ") {
            $sourcefilter = "SQL,ssrs,ssas"
        }

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
    }
    Process {   
        try {
            $ourObject = New-Object -TypeName psobject 
            $sourceArray = $sourcefilter.Split(",")
            $messageArray = $messagefilter.Split(",")
            $index = 0;
            #Build the Where array            
            $WhereArray = @()            
                        
            #If anything but the default * was provided, evaluate these with like comparison            
            foreach ($item in $sourceArray) {
              $WhereArray += '$_.source -like "*' + $item +'*"'
            }
            foreach ($item in $messageArray) {
                $WhereArray += '$_.message -like "*' + $item + '*"'
            }                    

            #Build the where array into a string by joining each statement with -or
            $WhereString = $WhereArray -Join " -or "            
                        
            #Create the scriptblock with your final string            
            $WhereBlock = [scriptblock]::Create( $WhereString )
            #$sb = [scriptblock]::Create("`$_.source -eq '.NET Runtime'")
            $event_log = (Get-EventLog -LogName "application" -EntryType Error | Where-Object { $WhereBlock.invoke() } )
            foreach ($item in $event_log) {
                $index += 1
                $output += ($event_log | Out-String).ToString()
                $Sourcekey = "Source " + $index
                $Messagekey = "Message " + $index
                $timekey = "Generated Time " + $index
                $ourObject | Add-Member -MemberType NoteProperty -Name $Sourcekey -Value $item.Source
                $ourObject | Add-Member -MemberType NoteProperty -Name $Messagekey -Value $item.Message
                $ourObject | Add-Member -MemberType NoteProperty -Name $timekey -Value $item.TimeGenerated
            }
            # $dd = "(Get-EventLog -LogName 'application' -EntryType Error | Where-Object { (`$_.source -like 'SQL') })"
            # Invoke-Command -ScriptBlock ([ScriptBlock]::Create($dd)) 
            # $sb = ConvertTo-ScriptBlock "(Get-EventLog -LogName 'application' -EntryType Error | Where-Object { (`$_.source -like 'SQL') })"
            # $sb
            # $dee = Invoke-Command -ScriptBlock $sb
            # $dee
            # foreach ($item in $sourceArray) {
            #     $filter = "*" +  $item + "*"
            #     #$event_log = (Get-EventLog -LogName "application" -EntryType Error | Where-Object { ($sb) } )
            #     #$event_log = (Get-EventLog -LogName "application" -EntryType Error | Where-Object { ($_.source -like $filter) } )
            #     $event_log = $sb.invoke()
            #     $event_log
            #     # foreach ($item in $event_log) {
            #     #     $index += 1
            #     #     $output += ($event_log | Out-String).ToString()
            #     #     $Sourcekey = "Source " + $index
            #     #     $Messagekey = "Message " + $index
            #     #     $timekey = "Generated Time " + $index
            #     #     $ourObject | Add-Member -MemberType NoteProperty -Name $Sourcekey -Value $item.Source
            #     #     $ourObject | Add-Member -MemberType NoteProperty -Name $Messagekey -Value $item.Message
            #     #     $ourObject | Add-Member -MemberType NoteProperty -Name $timekey -Value $item.TimeGenerated
            #     # }
            # }
            # foreach ($item2 in $messageArray) {
            #     if ($item2 -ne "") {
            #         $messagefilter = "*" +  $item2 + "*"
            #         $event_log = (Get-EventLog -LogName "application" -EntryType Error | Where-Object { ($_.message -like $messagefilter) } )
                   
            #         foreach ($item in $event_log) {
            #             $index += 1
            #             $output += ($event_log | Out-String).ToString()
            #             $Sourcekey = "Source " + $index
            #             $Messagekey = "Message " + $index
            #             $timekey = "Generated Time " + $index
            #             # [bool]($ourObject.PSobject.Properties.value -match $item.Source)
            #             # [bool]($ourObject.PSobject.Properties.value -match $item.Message) 
            #             # [bool]($ourObject.PSobject.Properties.value -match $item.TimeGenerated)
            #             $item.Message
            #             $recordExists = [bool]($ourObject.PSobject.Properties.value -match $item.Source) -and [bool]($ourObject.PSobject.Properties.value -match $item.Message) -and [bool]($ourObject.PSobject.Properties.value -match $item.TimeGenerated)
            #            # $recordExists
            #             if (!$recordExists) {
            #                 "33"
            #                 # $ourObject | Add-Member -MemberType NoteProperty -Name $Sourcekey -Value $item.Source
            #                 # $ourObject | Add-Member -MemberType NoteProperty -Name $Messagekey -Value $item.Message
            #                 # $ourObject | Add-Member -MemberType NoteProperty -Name $timekey -Value $item.TimeGenerated
            #             }
            #         }
            #     } 
            # }
        }
        catch {
            $err = $_
            $ErrorStackTrace = $_.ScriptStackTrace 
            $ErrorBlock = ($err).ToString() + "`n`nStackTrace: " + ($ErrorStackTrace).ToString()
            "Some error occured check " + $erroFile + " for stacktrace"
            $ourObject | Add-Member -MemberType NoteProperty -Name "Error" -Value $ErrorBlock
        }
    }
    End {
        return $ourObject
    }
}

Get-SqlErrorLog