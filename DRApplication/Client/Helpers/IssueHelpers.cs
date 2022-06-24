using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Helpers;
public static class IssueHelpers
{
    public static IssueInsertVm GetIssueInsertVmFromMaintenanceIssueVm(MaintenanceIssueInsertVm maintenanceIssueInsertVm)
    {
        var issue = new IssueInsertVm
        {
            Description = maintenanceIssueInsertVm.Description,
            EnteredBy = "ADMIN",
            IssueDate = maintenanceIssueInsertVm.IssueDate != null ? (DateTime)maintenanceIssueInsertVm.IssueDate : DateTime.Now,
            DrTypeId = maintenanceIssueInsertVm.IsContractor == true ? 2 : 1,
            SimStatusId = maintenanceIssueInsertVm.IsDeferred == true ? 12 : 13
        };
        return issue;
    }

    public static Issue GetIssueFromIssueInsertVm(IssueInsertVm issueInsertVm)
    {
        return new Issue
        {
            Description = issueInsertVm.Description,
            DrTypeId = issueInsertVm.DrTypeId,
            EnteredBy = issueInsertVm.EnteredBy,
            IssueDate = issueInsertVm.IssueDate,
            SimStatusId = issueInsertVm.SimStatusId
        };
    }
}
