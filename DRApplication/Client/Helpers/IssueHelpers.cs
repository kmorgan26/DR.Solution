using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Helpers;
public static class IssueHelpers
{
    // Gets the values for the Issues Table from the MI-View Model
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
    // Gets the values for the Issues Table
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
