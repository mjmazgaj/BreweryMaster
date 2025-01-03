﻿using BreweryMaster.API.OrderModule.Models;

public interface IProspectClientService
{
    Task<IEnumerable<ProspectClient>> GetProspectClientsAsync();
    Task<ProspectClient?> GetProspectClientByIdAsync(int id);
    Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest client);
    Task<bool> EditProspectClientAsync(int id, ProspectClient client);
    Task<bool> DeleteProspectClientByIdAsync(int id);
}