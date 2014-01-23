using System.ComponentModel;

namespace EnumHelperDemo
{
    public enum BasicCars
    {
        FourDoorSedan,
        FourByFour,
        SportsCar,
        Conbertable,
        PickUp,
    }

    public enum Cars
    {
        [Description("Four Door Sedan")]
        FourDoorSedan,

        [Description("4 x 4 ")]
        FourByFour,

        [Description("Sports Car")]
        SportsCar,

        [Description("Convertable")]
        Conbertable,

        [Description("Pick-Up Truck")]
        PickUp,
    }
}
