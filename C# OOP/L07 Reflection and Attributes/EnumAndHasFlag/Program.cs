Days promotion = Days.Saturday | Days.Monday;

if (promotion.HasFlag(Days.Saturday))
{
    Console.WriteLine("Saturday promo!");
}
if (promotion.HasFlag(Days.Monday))
{
    Console.WriteLine("Monday promo!");
}

enum Days
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 4,
    Thursday = 8,
    Friday = 16,
    Saturday = 32,
    Sunday = 64,
}