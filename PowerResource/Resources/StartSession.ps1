 function StartSession {
    Param(
        [Parameter(Mandatory = $false)]
        $computerName = $args[0],

        [Parameter(Mandatory = $false)]
        $user = $args[1],
		[Parameter(Mandatory = $false)]
        $pass = $args[2]
    )
    Begin {
      
    }
    Process {
      #machine-name SVRV-LB1
      #testadmin
      #ExtPSrun@dm1n
      $ProtocolStatus = [Ordered]@{}
	  $password = ConvertTo-SecureString $pass -AsPlainText -Force
      $pccred = New-Object System.Management.Automation.PSCredential ($user, $password )
      # Enter-PSSession –ComputerName $computerName -ServerInstance $windowsornetwork -Credential $$pccred
	  Enter-PSSession –ComputerName $computerName -Credential $$pccred
      # $WindowsVersion = (systeminfo | Select-String 'OS Version:')[0].ToString().Split(':')[1].Trim()
    }
	End {
        return $WindowsVersion
    }
  }
  StartSession