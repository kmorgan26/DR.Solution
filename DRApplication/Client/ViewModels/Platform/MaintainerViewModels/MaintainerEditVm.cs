using DRApplication.Client.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class MaintainerEditVm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}