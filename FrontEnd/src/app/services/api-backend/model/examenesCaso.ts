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
import { Examene } from './examene';
import { ResultadoExamene } from './resultadoExamene';
import { Cita } from './cita';
import { Usuario } from './usuario';


export interface ExamenesCaso { 
    idExamenCaso?: number;
    idExamen?: number;
    idCita?: number | null;
    idUsuario?: number;
    observaciones?: string | null;
    estado?: string | null;
    idCitaNavigation?: Cita;
    idExamenNavigation?: Examene;
    idUsuarioNavigation?: Usuario;
    resultadoExamenes?: Array<ResultadoExamene> | null;
}

