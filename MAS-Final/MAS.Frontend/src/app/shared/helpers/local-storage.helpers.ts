import { LocalStorageKeys } from '../enums/local-storage-keys.enum';
import { LoginSuccessProps } from '../../auth/+state/props/login-success.props';
import { DecodedUserData } from '../models/decoded-user-data';

export class LocalStorageHelpers {
  static getUser(token: string | undefined): DecodedUserData | undefined {
    if(token == undefined) {
      return undefined
    }

    return new LoginSuccessProps(token).user;
  }

  static setAccessToken(token: string): void {
    this.setItem(LocalStorageKeys.accessToken, token);
  }

  static getAccessToken(): string | undefined {
    return this.getItem(LocalStorageKeys.accessToken, undefined);
  }

  static removeAccessToken(): void {
    this.removeItem(LocalStorageKeys.accessToken);
  }

  static setRefreshToken(token: string): void {
    this.setItem(LocalStorageKeys.refreshToken, token);
  }

  static getRefreshToken(): string | null {
    return this.getItem(LocalStorageKeys.refreshToken, null);
  }

  static removeRefreshToken(): void {
    this.removeItem(LocalStorageKeys.refreshToken);
  }

  static setRefreshTokenExp(exp: number): void {
    this.setItem(LocalStorageKeys.refreshTokenExp, exp);
  }

  static getRefreshTokenExp(): number {
    return this.getItem(LocalStorageKeys.refreshTokenExp, 0);
  }

  static removeRefreshTokenExp(): void {
    this.removeItem(LocalStorageKeys.refreshTokenExp);
  }

  static setRedirectAfterLogin(target: string): void {
    this.setItem(LocalStorageKeys.redirectAfterLogin, target);
  }

  private static getItem<T>(key: LocalStorageKeys, defaultValue: T): T {
    const value = localStorage.getItem(key);

    if(value == null) {
      return defaultValue;
    }

    try {
      return JSON.parse(value);
    } catch (err) {
      return defaultValue;
    }
  }

  private static setItem<T>(key: LocalStorageKeys, value: T): void {
    if(!value) {
      localStorage.removeItem(key);
      return;
    }
    localStorage.setItem(key, JSON.stringify(value));
  }

  private static removeItem(key: LocalStorageKeys): void {
    localStorage.removeItem(key);
  }
}
