import { Gift } from "./Gifts";
import { User } from "./user";


export interface winner {

  Id?: number;
  UserId?: number;
  User?: User;
  GiftId?: number;
  Gift?: Gift;

}