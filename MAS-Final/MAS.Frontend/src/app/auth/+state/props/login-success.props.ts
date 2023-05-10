import { DecodedUserData } from '../../../shared/models/decoded-user-data';
import jwtDecode from 'jwt-decode';
import { JwtDecodedToken } from '../../../shared/models/jwt-decoded-token';

export class LoginSuccessProps {
  accessToken: string;
  user: DecodedUserData;

  constructor( accessToken: string ) {
    this.accessToken = accessToken;
    const decoded = jwtDecode<JwtDecodedToken>(accessToken);
    this.user = {
      userId: +decoded.nameid,
      name: decoded.name,
      email: decoded.email,
      exp: decoded.exp,
    }
  }
}
