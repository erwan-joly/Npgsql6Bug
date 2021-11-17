﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InMemoryPoc;

public class TestEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "jsonb")]
    public Dictionary<string, string>? Values { get; set; } = new();
}