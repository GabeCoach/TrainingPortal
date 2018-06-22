import { Injectable } from '@angular/core';
import { RestApiConfig } from '../enums/rest-config.enum';

@Injectable()
export class BaseService {

  constructor() { }

  BaseUrl = RestApiConfig.PROD_BASE_REST_URI;

}
