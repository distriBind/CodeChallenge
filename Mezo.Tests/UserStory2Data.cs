using System.Collections;

namespace Mezo.Tests
{
    internal static class CONSTANTS
    {
        internal static class COURIER_NAMES
        {
            internal static string ROYAL_MAIL => "Royal Mail";
            internal static string PANDA_PARCELS => "Panda Parcels";
        }
    }

    internal class UserStory2Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "Kent", true, CONSTANTS.COURIER_NAMES.ROYAL_MAIL
            };
            
            yield return new object[]
            {
                "Croydon", false, CONSTANTS.COURIER_NAMES.PANDA_PARCELS
            };
            yield return new object[]
            {
                "Thorton Heath", false, CONSTANTS.COURIER_NAMES.PANDA_PARCELS
            };
            yield return new object[]
            {
                "Dartford", false, CONSTANTS.COURIER_NAMES.PANDA_PARCELS
            };


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}