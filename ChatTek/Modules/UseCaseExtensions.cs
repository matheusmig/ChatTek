using Application.UseCases.CreateConversation;
using Application.UseCases.CreateParticipant;
using Application.UseCases.GetAllParticipants;
using Application.UseCases.RetrieveConversationByParticipantPaginated;
using Microsoft.Extensions.DependencyInjection;

namespace ChatTek.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddTransient<IRetrieveConversationsByParticipantPaginatedUseCase, RetrieveConversationsByParticipantPaginatedUseCase>();
                        
            serviceCollection.AddTransient<ICreateConversationUseCase, CreateConversationUseCase>();
            serviceCollection.Decorate<ICreateConversationUseCase, CreateConversationValidationUseCase>();

            serviceCollection.AddTransient<ICreateParticipantUseCase, CreateParticipantUseCase>();
            serviceCollection.Decorate<ICreateParticipantUseCase, CreateParticipantValidationUseCase>();
            
            serviceCollection.AddTransient<IGetAllParticipantsUseCase, GetAllParticipantsUseCase>();

            return serviceCollection;
        }
    }
}
