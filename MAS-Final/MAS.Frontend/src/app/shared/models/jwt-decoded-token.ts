import { JwtPayload } from 'jwt-decode';

export interface JwtDecodedToken extends JwtPayload {
  nameid: number;
  name: string;
  email: string;
}
