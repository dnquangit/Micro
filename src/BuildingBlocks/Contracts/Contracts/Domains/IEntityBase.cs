﻿namespace Contracts.Domains
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}
