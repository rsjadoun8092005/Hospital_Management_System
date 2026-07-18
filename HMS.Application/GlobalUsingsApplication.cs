global using System;
global using System.Collections.Generic;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Linq;
global using System.Reflection;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;


global using FluentValidation;
global using FluentValidation.Results;
global using MediatR;
global using AutoMapper;

global using HMS.Application.Exceptions;
global using HMS.Application.Commands;
global using HMS.Application.Queries;
global using HMS.Application.Responses;
global using HMS.Core.Common;
global using HMS.Core.Entities;
global using HMS.Core.IRepositories;
