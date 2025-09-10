namespace FanficAPP.UseCases.CreateFanfic;

public record CreateFanficPayload(
    string Title,
    string Text,
    Guid UserID
);