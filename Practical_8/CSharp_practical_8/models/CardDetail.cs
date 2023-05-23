﻿namespace CSharp_practical_8.models
{
    // Sealed Class
    public sealed class CardDetail
    {
        public long CardNumber { get; init; }
        public int CVV { get; init; }
        public int Pin { get; set; }
        public bool isActivate { get; set; } = false;
    }
}
