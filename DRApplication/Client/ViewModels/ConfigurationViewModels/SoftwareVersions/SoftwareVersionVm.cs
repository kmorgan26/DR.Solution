﻿namespace DRApplication.Client.ViewModels;

public class SoftwareVersionVm
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int SoftwareSystemId { get; set; }

    public DateTime VersionDate { get; set; }

}