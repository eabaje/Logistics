using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Enumerations
{
    
    public enum Parameter
    {
        Shipper = 1,
        Broker = 2,
        Carrier = 3
    }
    public enum LoadUnit
    {
        Kilo=1,
        Tonnes=2
       
    }

    public enum JourneyStatus
    {
        NotStarted ,
        InTransit ,
        Arrived,
        Delivered
    }
    public enum ShipmentType
    {
        FullContainer,
        PartContainer,
        Item
        
    }

    public enum ShipperType
    {
        Individual,
        Company,
       

    }
    public enum CarrierType
    {
        Air,
        Sea,
        Road
        

    }
    public enum FleetType
    {
        Vessel,
        Truck,
        Plane


    }
    public enum VesselType
    {
        Cargo,
        FishingBoat,
        Tanker


    }

    public enum CargoType
    {   RoRo,
        Container,
        LiquidBulk,
        BreakBulk,
        DryBulk,
        
       

    }
    public enum LoadCapacity
    {
         HighCapacity=24000,
        LowCapacity=2000,
        HeavyCapacity=25000,
        
    }

    public enum VehicleType
    {
        SemiTrailer,
        StraightTruck,
        JumboTrailer,
        TailLiftTruck,
        TruckTrailer,
        FlatbedTruck,
        LowboyTrailer,
        RefrigeratedTrailers,
        MiniBus
    }
    public enum Roles
    {
        Administrator,
        AppManager,
        Carrier,
        Broker,
        Shipper,
        Auditor
    }

    public enum PaymentMethod
    {
        Cash = 1,
        CreditCard = 2,
        DebitCard = 3,
        Paypal = 4

    }
    public enum OrderStatus
    {
        OrderMade = 1,
        Proceesed = 2,
        Delivered = 3
    }

    public enum Ratings
    {
        Bad = 1,
        Good = 2,
        VeryGood = 3,
        Excellent = 4,

    }
}
