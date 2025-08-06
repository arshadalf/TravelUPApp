using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using TravelUpApp_AI_ML.Models;

public class IndexModel : PageModel
{
    private readonly IConfiguration _config;
    public List<UserBehavior> UserList = new();

    public IndexModel(IConfiguration config)
    {
        _config = config;
    }

    public void OnGet()
    {
        using SqlConnection con = new(_config.GetConnectionString("DefaultConnection"));
        SqlCommand cmd = new("SELECT * FROM UserBehavior", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            UserList.Add(new UserBehavior
            {
                UserId = dr.GetString(0),
                SessionDuration = dr.GetDouble(1),
                PagesVisited = dr.GetInt32(2),
                SearchOrigin = dr.GetString(3),
                SearchDestination = dr.GetString(4),
                TravelDatesFlexible = dr.GetBoolean(5),
                DeviceType = dr.GetString(6),
                ClickedOffer = dr.GetBoolean(7),
                BookingMade = dr.GetBoolean(8)
            });
        }
    }
}
