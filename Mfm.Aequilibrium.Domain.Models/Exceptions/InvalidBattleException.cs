using System;

namespace Mfm.Aequilibrium.Domain.Models.Exceptions
{
    public class InvalidBattleException: Exception
    {
        public InvalidBattleException(string message): base(message)
        {
        }
    }
}
