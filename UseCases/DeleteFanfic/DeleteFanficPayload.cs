namespace FanficAPP.UseCases.DeleteFanfic;

public record EditListPayload(
    Guid UserID,
    Guid FanficID
);