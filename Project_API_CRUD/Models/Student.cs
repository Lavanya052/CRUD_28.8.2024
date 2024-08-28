using System;
using System.Collections.Generic;

namespace Project_API_CRUD.Models;

public partial class Students
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public decimal? MarkPer { get; set; }
}
