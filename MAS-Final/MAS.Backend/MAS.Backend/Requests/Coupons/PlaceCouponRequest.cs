namespace MAS.Backend.Requests.Coupons;

public record PlaceCouponRequest(int IdUser, int[] BetSportOptionIds, int[] BetEsportOptionIds ,float Amount); 