﻿namespace WeddingApi.Core.Models;

public class SongRequest
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Artist { get; set; }
}

