#Script to modify the action for an existing Windows Scheduled Task

$TaskName = "Rinker"
$PathToNewScript = "C:\Users\t_tod\OneDrive\Desktop\qq.ps1"

$Task = Get-ScheduledTask -TaskName $TaskName -ErrorAction SilentlyContinue
$TaskActions = $Task.Actions


if ($Task)
{
    $CurrentScript = $TaskActions[0].Execute
    Write-Host "Scheduled Task $TaskName exists."
    Write-Host "Scheduled Task's current action, executes this script: $CurrentScript "
    $Action = New-ScheduledTaskAction -Execute $PathToNewScript
    Set-ScheduledTask -TaskName $TaskName -Action $Action
    Write-Host "Changed to $PathToNewScript"
    Write-Host "Task has been updated. Please refresh the Scheduled Tasks window and confirm updates have been made."
}
else
{
    Write-Host "Scheduled task $TaskName does not exist."
}


