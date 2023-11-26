# PowerShell Script to Output Text from Stdin Starting From Specific Line

# Initialize a flag to start copying
$startCopying = $false

# Read each line from the standard input
$Input | ForEach-Object {
    # Check if the current line contains 'namespace Program'
    if ((-not $startCopying) -and ($_ -match "using System;")) {
        # Set the flag to start copying
        $startCopying = $true
    }

    # Output the line if the flag is set
    if ($startCopying) {
        $_
    }
}
