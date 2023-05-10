export interface EsportBetModel {
  idBet: number;
  dateTime: Date;
  idBetSport: number;
  game: string;
  team1: string;
  team2: string;
  options: EsportBetOption[];
}

export interface EsportBetOption {
  idBetEsportOption: number;
  odds: number;
  status: string;
  betName: string;
}

export interface EsportBetWithOption {
  idBet: number;
  dateTime: Date;
  idBetSport: number;
  game: string;
  team1: string;
  team2: string;
  idBetEsportOption: number;
  odds: number;
  status: string;
  betName: string;
}
