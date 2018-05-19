import * as React from 'react';
import styled from 'styled-components';
import Population from "./services/Population";
import DNA from "./services/DNA";

interface IAppState {
    bestPhrase: string;
    population: DNA[];
    averageFitness: number;
    totalGenerations: number;
    totalExecutionTime: number;
}

export default class App extends React.Component<any, IAppState> {
    protected targetPhrase: string = 'Just do it.';
    protected mutationRate: number = 0.01;
    protected maxPopulation: number = 150;
    protected population: Population;

    constructor(props: any) {
        super(props);
        this.evolve = this.evolve.bind(this);
        this.restart = this.restart.bind(this);

        this.state = {
            ...this.init(),
        };
    }

    public evolve(): void {
        const start = performance.now();
        // Prepare mating pool
        this.population.naturalSelection();

        // Generate new population
        this.population.generate();

        // Calculate fitness
        this.population.calcFitness();
        const end = performance.now();

        this.setState({
            ...this.getPopulationState(),
            totalExecutionTime: this.state.totalExecutionTime + (end - start)
        });

        if (this.population.best().getPhrase() !== this.targetPhrase) {
            window.requestAnimationFrame(this.evolve)
        }

    }

    public getPopulationState() {
        return {
            bestPhrase: this.population.best().getPhrase(),
            population: this.population.getPopulation(),
            averageFitness: this.population.averageFitness(),
            totalGenerations: this.population.getGeneration(),
        };
    }

    public restart() {
        this.setState({...this.init()});
    }

    public init() {
        this.population = new Population(this.targetPhrase, this.mutationRate, this.maxPopulation);

        this.population.calcFitness();
        return {
            ...this.getPopulationState(),
            totalExecutionTime: 0,
        };
    }

    public render() {
        return (
            <Wrapper>
                <Column>
                    <Title>Target phrase: {this.targetPhrase}</Title>
                    <Title>Best phrase: {this.state.bestPhrase}</Title>

                    <div>
                        total generations: {this.state.totalGenerations}<br/>
                        average fitness: {(this.state.averageFitness * 100).toFixed(2)}%<br/>
                        total population: {this.maxPopulation}<br/>
                        mutation rate: {this.mutationRate * 100}%<br/>
                        average execution
                        time: {(this.state.totalGenerations > 0) ? (this.state.totalExecutionTime / this.state.totalGenerations).toFixed(2) : 0}ms<br/>
                        <button onClick={this.evolve}>Start evolving</button>
                        <button onClick={this.restart}>Restart</button>
                    </div>
                </Column>
                <Column>
                    <ul>
                        {this.state.population.map((value, key) => <li key={key}>{value.getPhrase()}</li>)}
                    </ul>
                </Column>
            </Wrapper>
        );
    }
}

const Wrapper = styled.div`
    margin: 0 auto;
    max-width: 1000px;
    display: flex;
    flex-direction: row;
    justify-content: space-between
`;

const Title = styled.h1``;

const Column = styled.section``;