import Population from "../Population";
import DNA from "../DNA";

export default abstract class AbstractPool {
    protected population: Population;

    protected constructor(population: Population) {
        this.population = population;
    }

    public abstract naturalSelection(): void;

    public abstract generate(): DNA[];
}