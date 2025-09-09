namespace FanficAPP.UseCases.Getlist;

public record EditListPayload(
    Guid UserID,
    Guid ReadingListID,
    Guid FanficID
);