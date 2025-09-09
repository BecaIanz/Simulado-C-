namespace FanficAPP.UseCases.DeleteFanfic;

public record DeleteFanficPayload(
    Guid UserID,
    Guid FanficID
);