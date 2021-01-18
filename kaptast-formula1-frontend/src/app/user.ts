export class User {
    id: string;
    userName: string;
    password: string;

    constructor(name: string, password: string) {
        this.userName = name;
        this.password = password;
    }
}