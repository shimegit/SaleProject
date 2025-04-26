import { Donor } from "./donor";

export class Gift {

    id?: number;
    name?: string;
    donorName?: string;
    donorId?: number;
    tiketPrice?: number = 10;
    count?: number;
    imageUrl?: string;

}