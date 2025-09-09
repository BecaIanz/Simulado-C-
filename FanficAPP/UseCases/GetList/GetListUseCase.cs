using FanficAPP.Models;
using FanficAPP.UseCases.Getlist;
using Microsoft.EntityFrameworkCore;

namespace FanficAPP.UseCases.GetList;

public class GetListUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<GetListResponse>> Do(GetListPayload payload)
    {
        var lists = await ctx.ReadingLists
            .Include(r => r.FanficList) // ISSO EH MT IMPORTANTE
                .ThenInclude(f => f.User) // ISSO TMB
            .FirstOrDefaultAsync(l => l.Title == payload.Title);

        if (lists is null)
            return Result<GetListResponse>.Fail("Lista de Leitura não encontrada!");

        // CRIE RECORDS (PAYLOADS/DTO) PARA ARMAZENAR O RESULTADO DA QUERY
        // NUNCA RETORNAR MODELOS DO BANCO DE DADOS
        return Result<GetListResponse>.Success(new(lists));
    }
}