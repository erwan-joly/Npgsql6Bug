using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace Npgsql6;

public class TestEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "timestamp without timezone")]
    public Instant CreatedOn { get; set; }
}