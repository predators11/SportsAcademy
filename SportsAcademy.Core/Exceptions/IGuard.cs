﻿namespace SportsAcademy.Core.Exceptions
{
    public interface IGuard
    {
        void AgainstNull<T>(T value, string? errorMessage = null);
    }
}
