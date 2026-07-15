using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime _date_RP;
    private int _minutes_RP;

    public Activity(DateTime date_RP, int minutes_RP)
    {
        _date_RP = date_RP;
        _minutes_RP = minutes_RP;
    }

    public DateTime GetDate_RP()
    {
        return _date_RP;
    }

    public int GetMinutes_RP()
    {
        return _minutes_RP;
    }

    public abstract double GetDistance_RP(); // km
    public abstract double GetSpeed_RP();    // kph
    public abstract double GetPace_RP();     // min per km

    public virtual string GetSummary_RP()
    {
        string dateString_RP = _date_RP.ToString("dd MMM yyyy");
        string typeName_RP = GetType().Name.Replace("Activity", "");
        double distance_RP = GetDistance_RP();
        double speed_RP = GetSpeed_RP();
        double pace_RP = GetPace_RP();

        return $"{dateString_RP} {typeName_RP} ({_minutes_RP} min) - " +
               $"Distance {distance_RP:F1} km, Speed {speed_RP:F1} kph, Pace {pace_RP:F2} min per km";
    }
}

public class RunningActivity : Activity
{
    private double _distanceKm_RP;

    public RunningActivity(DateTime date_RP, int minutes_RP, double distanceKm_RP)
        : base(date_RP, minutes_RP)
    {
        _distanceKm_RP = distanceKm_RP;
    }

    public override double GetDistance_RP()
    {
        return _distanceKm_RP;
    }

    public override double GetSpeed_RP()
    {
        return (GetDistance_RP() / GetMinutes_RP()) * 60.0;
    }

    public override double GetPace_RP()
    {
        return GetMinutes_RP() / GetDistance_RP();
    }
}

public class CyclingActivity : Activity
{
    private double _speedKph_RP;

    public CyclingActivity(DateTime date_RP, int minutes_RP, double speedKph_RP)
        : base(date_RP, minutes_RP)
    {
        _speedKph_RP = speedKph_RP;
    }

    public override double GetDistance_RP()
    {
        return (_speedKph_RP * GetMinutes_RP()) / 60.0;
    }

    public override double GetSpeed_RP()
    {
        return _speedKph_RP;
    }

    public override double GetPace_RP()
    {
        return 60.0 / _speedKph_RP;
    }
}

public class SwimmingActivity : Activity
{
    private int _laps_RP;

    public SwimmingActivity(DateTime date_RP, int minutes_RP, int laps_RP)
        : base(date_RP, minutes_RP)
    {
        _laps_RP = laps_RP;
    }

    public override double GetDistance_RP()
    {
        // 50 m per lap → km
        return _laps_RP * 50.0 / 1000.0;
    }

    public override double GetSpeed_RP()
    {
        return (GetDistance_RP() / GetMinutes_RP()) * 60.0;
    }

    public override double GetPace_RP()
    {
        return GetMinutes_RP() / GetDistance_RP();
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities_RP = new List<Activity>()
        {
            new RunningActivity(new DateTime(2026, 7, 14), 30, 4.8),
            new CyclingActivity(new DateTime(2026, 7, 13), 45, 20.0),
            new SwimmingActivity(new DateTime(2026, 7, 12), 25, 30)
        };

        foreach (Activity activity_RP in activities_RP)
        {
            Console.WriteLine(activity_RP.GetSummary_RP());
        }
    }
}
