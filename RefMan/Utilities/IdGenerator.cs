﻿namespace RefMan.Utilities
{
    using IdGeneratorLib = IdGen.IdGenerator;

    public static class IdGenerator
    {
        private static readonly IdGeneratorLib Generator = new IdGeneratorLib(0);

        public static long GenerateUserId()
        {
            return GenerateId();
        }

        private static long GenerateId()
        {
            return Generator.CreateId();
        }
    }
}