[CmdletBinding()]
param(
    [Alias("i")]
    [switch]$Interactive,

    [Alias("h")]
    [switch]$Help
)

function Show-Help {
    @"
    Usage:
        -Interactive, -i  Enter interactive mode
        -Help, -h         Show this help message
"@
}

function Enter-InteractiveMode {
        Write-Host "Entering interactive mode..."
        $contestName = Read-Host "Enter a name"
        $problems = @('a', 'b', 'c', 'd')
        foreach ($p in $problems) {
            $template = "$contestName-$p.linq"
            Write-Host "Copying template.linq to $template"
            cp ./template.linq $template
        }
}
            
# Show help if no arguments or -h is provided
if ($PSBoundParameters.Count -eq 0 -or $Help) {
    Show-Help
    exit
}

# Enter interactive mode if -i is provided
if ($Interactive) {
    Enter-InteractiveMode
}

