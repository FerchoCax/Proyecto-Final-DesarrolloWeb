/**
 * Api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { Paciente } from './paciente';
import { Sucursale } from './sucursale';
import { Departamento } from './departamento';


export interface Municipio { 
    idMunipio?: number;
    idDepartamento?: number;
    nombre?: string | null;
    idDepartamentoNavigation?: Departamento;
    pacientes?: Array<Paciente> | null;
    sucursales?: Array<Sucursale> | null;
}

